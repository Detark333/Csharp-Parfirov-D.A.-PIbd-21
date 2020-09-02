using AbstractJewerlyStoreBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    public class ImplementerViewModel : BaseViewModel
    {
        [Column(title: "FIO Implementer", width: 300)]
        public string ImplementerFIO { get; set; }
        [Column(title: "Time for order", width: 100)]
        public int WorkingTime { get; set; }
        [Column(title: "Time for chill", width: 100)]
        public int PauseTime { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "ImplementerFIO", "WorkingTime", "PauseTime" };
    }
}
