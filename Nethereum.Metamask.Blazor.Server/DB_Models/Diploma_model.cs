using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nethereum.Metamask.Blazor.Server.DB_Models
{
    public class Diploma_model
    {
        [Key]
        public System.Nullable<int> ID { get; set; }
        public System.Nullable<int> SB_nr { get; set; } 
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public System.Nullable<int> IdentityNumber { get; set; }
        public string StudiesProgram { get; set; }
        public string Studiesdirection { get; set; } 
        public string RegistrationNr { get; set; } 
        public DateTime DateOfIssue { get; set; }
        public string Hash { get; set; }
        public System.Nullable<int> Status { get; set; }
    }
}
