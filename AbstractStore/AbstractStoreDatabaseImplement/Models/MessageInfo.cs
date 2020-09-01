using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractStoreDatabaseImplement.Models
{
    public class MessageInfo
    {
        [Key]
        public string MessageId { get; set; }
        public int? ClientId { get; set; }
        public string SenderName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public virtual Client Client { get; set; }
    }
}
