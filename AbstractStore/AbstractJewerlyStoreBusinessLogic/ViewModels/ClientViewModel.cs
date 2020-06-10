using AbstractJewerlyStoreBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        [Column(title: "FIO Client", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { set; get; }
        [DataMember]
        public string Login { set; get; }
        [DataMember]
        public string Password { set; get; }
        public override List<string> Properties() => new List<string> { "Id", "ClientFIO" };
    }
}
