using AbstractJewerlyStoreBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public string CreationDate { get; set; }
        public List<Tuple<string, decimal>> OrdersAmounts { get; set; }
        public decimal Amount { get; set; }
    }
}
