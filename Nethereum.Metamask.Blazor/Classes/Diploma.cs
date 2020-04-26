using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nethereum.Metamask.Blazor.Classes
{
    public class Diploma
    {
        [Required]
        [StringLength(10, ErrorMessage = "SB is too long.")]
        public int SB_nr { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Identity Number too long")]
        public int IdentityNumber { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Program too long")]
        public string SutdiesProgram { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Direction too long")]
        public string Studiesdirection { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "registration nr too long")]
        public string RegistrationNr { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }
    }
}
