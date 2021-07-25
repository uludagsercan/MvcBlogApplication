using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [StringLength(50)]
        public String UserName { get; set; }
        [StringLength(50)]
        public String UserMail { get; set; }
        [StringLength(50)]
        public String Subject { get; set; }
        [StringLength(255)]

        public String Message { get; set; }
        public bool ContactStatus { get; set; }
        public DateTime ContactDate { get; set; }

        public bool ReadStatus { get; set; }
    }
}
