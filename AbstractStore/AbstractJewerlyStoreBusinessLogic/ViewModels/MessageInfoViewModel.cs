
﻿using AbstractJewerlyStoreBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    [DataContract]
    public class MessageInfoViewModel : BaseViewModel
    {
        [DataMember]
        public string MessageId { get; set; }
        [Column(title: "Sender", width: 150)]
        [DataMember]
        public string SenderName { get; set; }
        [Column(title: "Date of the letter", width: 100)]
        [DataMember]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Header", width: 150)]
        [DataMember]
        public string Subject { get; set; }
        [Column(title: "Text", width: 200)]
        [DataMember]
        public string Body { get; set; }
        public override List<string> Properties() => new List<string> { "MessageId", "SenderName", "DateDelivery", "Subject", "Body" };
    }
}
