using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nethereum.Metamask.Blazor.Server.Classes
{
    public class Diploma_frontend
    {
        [Required]
        //[StringLength(10, ErrorMessage = "SB is too long.")]
        public int SB_nr { get; set; } = 1000;

        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        public string Name { get; set; } = "Arnas";

        [Required]
        [StringLength(20, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; } = "Kučinskas";

        [Required]
        //[StringLength(12, ErrorMessage = "Identity Number too long")]
        public int IdentityNumber { get; set; } = 356974556;

        [Required]
        [StringLength(50, ErrorMessage = "Program too long")]
        public string SutdiesProgram { get; set; } = "IT Inzinerija";

        [Required]
        [StringLength(50, ErrorMessage = "Direction too long")]
        public string Studiesdirection { get; set; } = "IT technologijos";

        [Required]
        [StringLength(10, ErrorMessage = "registration nr too long")]
        public string RegistrationNr { get; set; } = "IT-1455";

        [Required]
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
    }
}
