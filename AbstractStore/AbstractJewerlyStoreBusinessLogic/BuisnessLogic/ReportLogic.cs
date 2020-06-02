using DocumentFormat.OpenXml;
using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.HelperModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AbstractJewerlyStoreBusinessLogic.BuisnessLogic
{
    public class ReportLogic
    {
        private readonly IJewerlyLogic jewerlyLogic;
        private readonly IProductLogic productLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IProductLogic productLogic, IJewerlyLogic jewerlyLogic, IOrderLogic orderLogic)
        {
            this.productLogic = productLogic;
            this.jewerlyLogic = jewerlyLogic;
            this.orderLogic = orderLogic;
        }
        public List<ReportProductJewerlyViewModel> GetProductJewerlies()
        {
            var list = new List<ReportProductJewerlyViewModel>();
            var products = productLogic.Read(null);
            foreach (var product in products)
            {
                var productRec = new ReportProductJewerlyViewModel
                {
                    ProductName = product.ProductName,
                    JewerlyName = " ",
                };
                list.Add(productRec);
                foreach (var part in product.ProductJewerlies)
                {
                    var partRec = new ReportProductJewerlyViewModel
                    {
                        ProductName = " ",
                        JewerlyName = part.Value.Item1,
                        Count = part.Value.Item2
                    };
                    list.Add(partRec);
                }
            }
            return list;
        }
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            List<OrderViewModel> orders = orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            return orders.GroupBy(o => o.DateCreate.ToShortDateString())
            .Select(g => new ReportOrdersViewModel
            {
                CreationDate = g.Key,
                OrdersAmounts = g.Select(o =>
                new Tuple<string, decimal>(o.ProductName, o.Count)).ToList(),
                Amount = g.Sum(o => o.Count)
            }).ToList();
        }
        public void SaveJewerliesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изготовлений",
                Products = productLogic.Read(null)
            });
        }
        public void SaveProductJewerlyToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Двигатели-детали",
                ProductJewerlies = GetProductJewerlies()
            });
        }
    }

}
