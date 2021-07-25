using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
       
        public int MessageId { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        [StringLength(50)]
        public string MessageSubject { get; set; }
      
        [AllowHtml]
        public string MessageContent { get; set; }
        public bool MessageDraftStatus { get; set; }
        public bool MessageStatus { get; set; }
        public DateTime MessageDate { get; set; }
        public bool ReadStatus { get; set; }
    }
}
