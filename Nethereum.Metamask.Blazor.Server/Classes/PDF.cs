using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Properties;
using System.IO;
using System.Security.Cryptography;
using Nethereum.Metamask.Blazor.Server.DB_Models;

namespace Nethereum.Metamask.Blazor.Server.Classes
{
    public class PDF
    {
        //private SHA256 documentHash = SHA256.Create();
        private string documentHash;
        private static string pdfDestination = "D:\\pdf\\{0}.pdf";
        private string imageDestination = "D:\\pdf\\diploma.jpg";
        private SHA256 Sha256 = SHA256.Create();

        public PDF(int hash )
        {
            //documentHash = hash;
            pdfDestination = String.Format(pdfDestination, hash);
        }
        public PDF()
        {
            
        }

        public string CreatePDF(Diploma_model diploma)
        {
            var bytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            string randomString = BitConverter.ToString(bytes);
            pdfDestination = String.Format(pdfDestination, randomString);
            //Create PDF
            SetPdfBackground(diploma);
            //get PDF hash
            return documentHash = GetHashSha256(pdfDestination);

        }

        public void CreartePDF()
        {
            SetPdfBackground();
            documentHash = GetHashSha256(pdfDestination);

        }

        private void SetPdfBackground(Diploma_model diploma)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(pdfDestination));
            //PageSize pageSize = PageSize.A4.Rotate();
            PageSize pageSize = PageSize.A4.Rotate();
            Document doc = new Document(pdfDoc, pageSize);

            PdfCanvas canvas = new PdfCanvas(pdfDoc.AddNewPage());
            canvas.AddImage(ImageDataFactory.Create(imageDestination), pageSize, false);

            doc.Add(new Paragraph(diploma.Name));
            PdfFont times_new_roman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            doc.Add(new Paragraph(diploma.LastName).SetFont(times_new_roman).SetFontSize(50).SetTextAlignment(TextAlignment.CENTER));

            doc.Close();
        }

        private string GetHashSha256(string filename)
        {
            string result = "";
            using (FileStream stream = File.OpenRead(filename))
            {
                byte[] bytes = Sha256.ComputeHash(stream);
                foreach (byte b in bytes)
                {
                    result += b.ToString("x2");
                }
            }
            try
            {
                File.Delete(filename);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        private void SetPdfBackground()
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(pdfDestination));
            //PageSize pageSize = PageSize.A4.Rotate();
            PageSize pageSize = PageSize.A4;
            Document doc = new Document(pdfDoc, pageSize);

            PdfCanvas canvas = new PdfCanvas(pdfDoc.AddNewPage());
            canvas.AddImage(ImageDataFactory.Create(imageDestination), pageSize, false);

            doc.Add(new Paragraph("Berlin!"));
            PdfFont times_new_roman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            doc.Add(new Paragraph("lalala").SetFont(times_new_roman).SetFontSize(50).SetTextAlignment(TextAlignment.CENTER));

            doc.Close();
        }
    }
}
