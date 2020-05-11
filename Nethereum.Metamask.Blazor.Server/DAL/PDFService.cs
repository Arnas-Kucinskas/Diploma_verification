using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Nethereum.Metamask.Blazor.Server.DB_Models;
using Nethereum.Metamask.Blazor.Server.Classes;
using System.IO;

namespace Nethereum.Metamask.Blazor.Server.DAL
{
    public class PDFService
    {
        private readonly VerContext _db;

        public PDFService(VerContext db)
        {
            _db = db;
        }


        public MemoryStream GetPDFForDownload(Diploma_model diploma)
        {
            PdfInfo pdfinfo = _db.pdfInfos.FirstOrDefault(s => s.diplomaID == diploma.ID);
            byte[] pdfbytes = Convert.FromBase64String(pdfinfo.pdfBase64Code);
            MemoryStream stream = new MemoryStream(pdfbytes);
            return stream;
        }

        public string UpdatePDF(Diploma_model diploma, String updatedPDF)
        {
            PdfInfo pdfinfo = _db.pdfInfos.FirstOrDefault(s => s.diplomaID == diploma.ID);
            pdfinfo.pdfBase64Code = updatedPDF;
            _db.pdfInfos.Update(pdfinfo);
            return "Save successfull";
        }
        public PdfInfo GetPDFByDiplomaID(Diploma_model diploma)
        {
            PdfInfo pdfInfo = _db.pdfInfos.FirstOrDefault(s => s.diplomaID == diploma.ID);
            return pdfInfo;
        }


        public string AddPDF(PdfInfo pdf)
        {
            _db.pdfInfos.Add(pdf);
            _db.SaveChanges();
            return "Save Successfully";
        }
    }
}
