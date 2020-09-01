using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    [DataContract]
    public class MessageInfoViewModel
    {
        [DataMember]
        public string MessageId { get; set; }
        [DisplayName("Отправитель")]
        [DataMember]
        public string SenderName { get; set; }
        [DisplayName("Дата получения")]
        [DataMember]
        public DateTime DeliveryDate { get; set; }
        [DisplayName("Заголовок")]
        [DataMember]
        public string Subject { get; set; }
        [DisplayName("Текст")]
        [DataMember]
        public string Body { get; set; }
    }
}
