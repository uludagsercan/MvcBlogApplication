using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        
        public String ContentDescription { get; set; }
        [StringLength(100)]
        public String ContentImage { get; set; }
        public DateTime ContentDate { get; set; }
        public bool ContentStatus { get; set; }
        public int HeadingId { get; set; }
        public int? WriterId { get; set; }
        public virtual Heading Heading { get; set; }
        public virtual Writer Writer { get; set; }


    }
}
