using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Nethereum.Metamask.Blazor.Server.DB_Models
{
    public class PdfInfo
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("diploma")]
        public  int diplomaID { get; set; }
        public String pdfBase64Code { get; set; }

        [IgnoreDataMember]
        public virtual Diploma_model diploma { get; set; }
    }
}
