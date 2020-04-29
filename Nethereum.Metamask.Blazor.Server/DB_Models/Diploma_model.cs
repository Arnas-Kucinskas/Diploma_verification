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
        public int ID { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdentityNumber { get; set; }
        public string StudiesProgramme { get; set; }
        public string StudiesProgrammeGovermentCode { get; set; } = "GN-00001";
        public string Degree { get; set; }
        public string Studiesdirection { get; set; }
        public string RectorsName { get; set; } = "Vardenis";
        public string RectorsLastName { get; set; } = "Pavaardenis";
        public string RegistrationNr { get; set; } = "GN-RNR0001";
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public System.Nullable<int> SB_nr { get; set; } = 000001;



 


        public string Hash { get; set; }
        public System.Nullable<int> Status { get; set; }
        public string transactionHash { get; set; }
    }
}
