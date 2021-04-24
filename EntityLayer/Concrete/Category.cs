using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public String CategoryName { get; set; }
       
        public DateTime CategoryDate { get; set; }
        public bool CategoryStatus { get; set; }
       // public int WriterId { get; set; }
        //public virtual Writer Writer { get; set; }

        public ICollection<Heading> Headings { get; set; }

    }
}
