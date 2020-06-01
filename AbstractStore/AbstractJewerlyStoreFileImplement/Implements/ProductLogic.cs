using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractJewerlyStoreFileImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly FileDataListSingleton source;
        public ProductLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }        public void CreateOrUpdate(ProductBindingModel model)
        {
            Product element = source.Products.FirstOrDefault(rec => rec.ProductName ==
           model.ProductName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Products.Count > 0 ? source.Jewerlies.Max(rec =>
               rec.Id) : 0;
                element = new Product { Id = maxId + 1 };
                source.Products.Add(element);
            }
            element.ProductName = model.ProductName;
            element.Price = model.Price;
            source.ProductJewerlies.RemoveAll(rec => rec.ProductId == model.Id &&
           !model.ProductJewerlies.ContainsKey(rec.JewerlyId));
            var updateComponents = source.ProductJewerlies.Where(rec => rec.ProductId ==
           model.Id && model.ProductJewerlies.ContainsKey(rec.JewerlyId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count =
               model.ProductJewerlies[updateComponent.JewerlyId].Item2;
                model.ProductJewerlies.Remove(updateComponent.JewerlyId);
            }
            int maxPCId = source.ProductJewerlies.Count > 0 ?
           source.ProductJewerlies.Max(rec => rec.Id) : 0;
            foreach (var pc in model.ProductJewerlies)
            {
                source.ProductJewerlies.Add(new ProductJewerly
                {
                    Id = ++maxPCId,
                    ProductId = element.Id,
                    JewerlyId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(ProductBindingModel model)
        {
            source.ProductJewerlies.RemoveAll(rec => rec.ProductId == model.Id);
            Product element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Products.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            return source.Products
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ProductViewModel
            {
                Id = rec.Id,
                ProductName = rec.ProductName,
                Price = rec.Price,
                ProductJewerlies = source.ProductJewerlies
            .Where(recPC => recPC.ProductId == rec.Id)
            .ToDictionary(recPC => recPC.JewerlyId, recPC =>
            (source.Jewerlies.FirstOrDefault(recC => recC.Id == recPC.JewerlyId)?.JewerlyName, recPC.Count))
            })
            .ToList();
        }
    }
}
