using AbstractJewerlyStoreBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    public class ProductJewerlyViewModel : BaseViewModel
    {
        public int PizzaId { get; set; }
        public int JewerlytId { get; set; }
        [Column(title: "Jewerly", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string JewerlyName { get; set; }
        [Column(title: "Count", width: 100)]
        public int Count { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "JewerlyName", "Count" };
    }
}
