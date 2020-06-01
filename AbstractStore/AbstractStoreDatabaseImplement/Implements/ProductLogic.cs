using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractStoreDatabaseImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        public void CreateOrUpdate(ProductBindingModel model)
        {
            using (var context = new AbstractStoreDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Product element = context.Products.FirstOrDefault(rec =>
                        rec.ProductName == model.ProductName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Products.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Product();
                            context.Products.Add(element);
                        }
                        element.ProductName = model.ProductName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.ProductJewerlies.Where(rec
                                => rec.ProductId == model.Id.Value).ToList();

                            context.ProductJewerlies.RemoveRange(productComponents.Where(rec =>
                            !model.ProductJewerlies.ContainsKey(rec.JewerlyId)).ToList());
                            context.SaveChanges();

                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count =
                               model.ProductJewerlies[updateComponent.JewerlyId].Item2;

                                model.ProductJewerlies.Remove(updateComponent.JewerlyId);
                            }
                            context.SaveChanges();
                        }

                        foreach (var pc in model.ProductJewerlies)
                        {
                            context.ProductJewerlies.Add(new ProductJewerly
                            {
                                ProductId = element.Id,
                                JewerlyId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(ProductBindingModel model)
        {
            using (var context = new AbstractStoreDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        context.ProductJewerlies.RemoveRange(context.ProductJewerlies.Where(rec =>
                        rec.ProductId == model.Id));
                        Product element = context.Products.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Products.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            using (var context = new AbstractStoreDatabase())
            {
                return context.Products
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new ProductViewModel
               {
                   Id = rec.Id,
                   ProductName = rec.ProductName,
                   Price = rec.Price,
                   ProductJewerlies = context.ProductJewerlies
                .Include(recPC => recPC.Jewerly)
                .Where(recPC => recPC.ProductId == rec.Id)
                .ToDictionary(recPC => recPC.ProductId, recPC =>
                (recPC.Product?.ProductName, recPC.Count))
               }).ToList();
            }
        }
    }
}
