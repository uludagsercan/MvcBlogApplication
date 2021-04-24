﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        public String WriterName { get; set; }
        [StringLength(50)]
        public String WriterSurname { get; set; }
        [StringLength(100)]
        public String WriterImage { get; set; }
        [StringLength(50)]
        public String WriterEmail { get; set; }
        [StringLength(20)]
        public String WriterPassword { get; set; }
        public DateTime WriterDate { get; set; }

        public ICollection<Content> Contents { get; set; }
       // public ICollection<Category> Categories { get; set; }
        public ICollection<Heading> Headings { get; set; }

    }
}
