using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractStoreListImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly DataListSingleton source;
        public ProductLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            Product tempProduct = model.Id.HasValue ? null : new Product { Id = 1 };
            foreach (var product in source.Products)
            {
                if (product.ProductName == model.ProductName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempProduct == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Products.Add(CreateModel(model, tempProduct));
            }
        }
        public void Delete(ProductBindingModel model)
        {
            for (int i = 0; i < source.ProductJewerlies.Count; ++i)
            {
                if (source.ProductJewerlies[i].ProductId == model.Id)
                {
                    source.ProductJewerlies.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }        private Product CreateModel(ProductBindingModel model, Product product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.ProductJewerlies.Count; ++i)
            {
                if (source.ProductJewerlies[i].Id > maxPCId)
                {
                    maxPCId = source.ProductJewerlies[i].Id;
                }
                if (source.ProductJewerlies[i].ProductId == product.Id)
                {
                    if
                    (model.ProductJewerlies.ContainsKey(source.ProductJewerlies[i].JewerlyId))
                    {
                        source.ProductJewerlies[i].Count = model.ProductJewerlies[source.ProductJewerlies[i].JewerlyId].Item2;
                        model.ProductJewerlies.Remove(source.ProductJewerlies[i].JewerlyId);
                    }
                    else
                    {
                        source.ProductJewerlies.RemoveAt(i--);
                    }
                }
            }
            foreach (var pc in model.ProductJewerlies)
            {
                source.ProductJewerlies.Add(new ProductJewerly
                {
                    Id = ++maxPCId,
                    ProductId = product.Id,
                    JewerlyId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var component in source.Products)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private ProductViewModel CreateViewModel(Product product)
        {
        Dictionary<int, (string, int)> productComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in source.ProductJewerlies)
            {
                if (pc.ProductId == product.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Jewerlies)
                    {
                        if (pc.JewerlyId == component.Id)
                        {
                            componentName = component.JewerlyName;
                            break;
                        }
                    }
                    productComponents.Add(pc.JewerlyId, (componentName, pc.Count));
                }
            }
            return new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductJewerlies = productComponents
            };
        }
    }
}
