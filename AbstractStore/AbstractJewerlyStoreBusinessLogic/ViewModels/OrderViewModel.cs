using AbstractJewerlyStoreBusinessLogic.Attributes;
using AbstractJewerlyStoreBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    [DataContract]

    public class OrderViewModel : BaseViewModel
    {
        
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [Column(title: "Client", width: 150)]
        public string ClientLogin { get; set; }
        [Column(title: "Implementer", width: 150)]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Product", width: 150)]
        public string ProductName { get; set; }
        [DataMember]
        [Column(title: "Count", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Sum", width: 50)]
        public decimal Sum { get; set; }
        [DataMember]
        [Column(title: "Status", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Date of Creation", width: 100)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Date of Implemention", width: 100)]
        public DateTime? DateImplement { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "ClientLogin", "ProductName", "ImplementerFIO", "Count", "Sum", "Status", "DateCreate", "DateImplement" };

    }
}
