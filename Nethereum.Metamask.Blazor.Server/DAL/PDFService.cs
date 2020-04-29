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

        public MemoryStream GetPDF(Diploma_model diploma)
        {
            PdfInfo pdfinfo = _db.pdfInfos.FirstOrDefault(s => s.diplomaID == diploma.ID);
            byte[] pdfbytes = Convert.FromBase64String(pdfinfo.pdfBase64Code);
            MemoryStream stream = new MemoryStream(pdfbytes);
            return stream;
        }

        public Diploma_model GetDiplomaByID(int id)
        {
            Diploma_model diploma = _db.Diploma.FirstOrDefault(s => s.ID == id);
            return diploma;
        }
        public string AddPDF(PdfInfo pdf)
        {
            _db.pdfInfos.Add(pdf);
            _db.SaveChanges();
            return "Save Successfully";
        }
    }
}
