using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractJewerlyStoreFileImplement.Models
{
    public class MessageInfo
    {
        public string MessageId { get; set; }
        public int? ClientId { get; set; }
        public string SenderName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
