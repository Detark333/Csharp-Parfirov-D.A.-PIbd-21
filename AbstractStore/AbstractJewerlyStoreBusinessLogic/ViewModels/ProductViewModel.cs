using AbstractJewerlyStoreBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    [DataContract]
    public class ProductViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Product", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ProductName { get; set; }
        [DataMember]
        [Column(title: "Price", width: 50)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> ProductJewerlies { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "ProductName", "Price" };
    }
}
