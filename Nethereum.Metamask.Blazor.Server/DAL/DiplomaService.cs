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
    public class DiplomaService
    {
        private readonly VerContext _db;

        public DiplomaService(VerContext db)
        {
            _db = db;
        }

        public List<Diploma_model> GetAllDiplomas()
        {
            var emptyList = _db.Diploma.ToList();
            return emptyList;
        }
        public List<Diploma_model> GetAllDiplomas(int status)
        {
            var list = _db.Diploma.Where(s => s.Status == status).ToList();
            return list;
        }

        public List<Diploma_model> GetAllDiplomasInQueue()
        {
            var list = _db.Diploma.Where(s => s.Status == 0).ToList();
            return list;
        }

        public string Create(Diploma_model objDimploma)
        {
            //Default value
            objDimploma.Status = 0; // Waiting for verification 

            //Create PDF and get its hash
            PDF pdf = new PDF();
            Tuple<string, String> diplomaInfo = pdf.CreatePDF(objDimploma);
            objDimploma.Hash = diplomaInfo.Item1;
            PdfInfo pdfInfo = new PdfInfo();
            pdfInfo.diploma = objDimploma;
            pdfInfo.pdfBase64Code = diplomaInfo.Item2;
            //Check forduplicates
            //
            _db.Diploma.Add(objDimploma);
            _db.pdfInfos.Add(pdfInfo);
            _db.SaveChanges();
            return "Save Successfully";
        }

        public Diploma_model GetDiplomaByID(int id)
        {
            Diploma_model diploma = _db.Diploma.FirstOrDefault(s => s.ID == id);
            return diploma;
        }

        public string UpdateDiploma(Diploma_model objDiploma)
        {
            _db.Diploma.Update(objDiploma);
            _db.SaveChanges();
            return "Update succesfully";
        }
        public string UpdateDiplomas(List<Diploma_model> objDiploma, int status)
        {
            foreach (var item in objDiploma)
            {
                item.Status = status;
                _db.Diploma.Update(item);
            }
            _db.SaveChanges();
            return "Update succesfully";
        }

        public string DeleteDiploma(Diploma_model objDiploma)
        {
            _db.Remove(objDiploma);
            _db.SaveChanges();
            return "Deleted successfully";
        }
    }
}
