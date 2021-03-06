﻿using System;
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

        public Diploma_model GetDiplomaBySearchID(string searchString)
        {
            var list = _db.Diploma.Where(s => s.quickSearch == searchString).ToList();
            if (list.Count == 1)
            {
                return list[0];
            }
            return null;
        }
        public Diploma_model GetDiplomaByHash(string hash)
        {
            var list = _db.Diploma.Where(s => s.Hash == hash).ToList();
            if (list.Count == 1)
            {
                return list[0];
            }
            return null;
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
            bool notUniqueQuickSearch = true;
            while (notUniqueQuickSearch)
            {
                string quickSearch = GetRandom(10);
                Diploma_model tmpDiploma = _db.Diploma.FirstOrDefault(s => s.quickSearch == quickSearch);
                if (tmpDiploma == null)
                {
                    notUniqueQuickSearch = false;
                }
                objDimploma.quickSearch = quickSearch;
            }

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
            _db.SaveChanges();
            _db.pdfInfos.Add(pdfInfo);
            _db.SaveChanges();
            //_db.Dispose();
            //pdfInfo.pdfBase64Code = null;
            return "Save Successfully";
        }

        private string GetRandom(int length)
        {
            const string chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
        public Diploma_model GetDiplomaByID(int id)
        {
            Diploma_model diploma = _db.Diploma.FirstOrDefault(s => s.ID == id);
            return diploma;
        }

        public String UpdateDiploma(Diploma_model objDiploma)
        {
            PDF pdf = new PDF();
            Tuple<string, String> diplomaInfo = pdf.CreatePDF(objDiploma);
            objDiploma.Hash = diplomaInfo.Item1;

            _db.Diploma.Update(objDiploma);
            _db.SaveChanges();
            return diplomaInfo.Item2;
        }
        public string UpdateDiplomas(List<Diploma_model> objDiploma, int status, string _transactionHash)
        {
            foreach (var item in objDiploma)
            {
                item.transactionHash = _transactionHash;
                item.Status = status;
                _db.Diploma.Update(item);
            }
            _db.SaveChanges();
            return "Update succesfully";
        }
        public string UpdateDiplomas(List<Diploma_model> objDiploma)
        {
            foreach (var item in objDiploma)
            {
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
