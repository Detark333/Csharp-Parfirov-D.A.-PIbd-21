using AbstractJewerlyStoreBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    public class JewerlyViewModel : BaseViewModel
    {
        [Column(title: "Jewerly", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string JewerlyName { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "JewerlyName" };
    }
}
