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
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new AbstractStoreDatabase())
            {
                Order element = new Order();
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    else
                    {
                        element.Count = model.Count;
                        element.Sum = model.Sum;
                        element.DateCreate = model.CreationDate;
                        element.DateImplement = model.CompletionDate;
                        element.Status = model.Status;
                        element.ProductId = model.ProductId;
                    }
                }
                else
                {
                    element = new Order
                    {
                        Count = model.Count,
                        Sum = model.Sum,
                        DateCreate = model.CreationDate,
                        DateImplement = model.CompletionDate,
                        Status = model.Status,
                        ProductId = model.ProductId
                    };
                    context.Orders.Add(element);
                }

                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new AbstractStoreDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }

                context.SaveChanges();
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new AbstractStoreDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Product)
                .Where(rec => model == null || rec.Id == model.Id
                || model.DateFrom.HasValue && model.DateTo.HasValue
                && rec.DateCreate >= model.DateFrom.Value
                && rec.DateCreate <= model.DateTo.Value)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status,
                    ProductId = rec.ProductId,
                    ProductName = rec.Product.ProductName
                }).ToList();
            }
        }
    }
}
