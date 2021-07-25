using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [StringLength(100)]
        public string PersonFullName { get; set; }
        [StringLength(150)]
        public string PersonDepartment { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
