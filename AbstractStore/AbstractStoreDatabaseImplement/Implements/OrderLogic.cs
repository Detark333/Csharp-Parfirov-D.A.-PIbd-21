using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Enums;
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
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.ClientId = model.ClientId.Value;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.ImplementerId = model.ImplementerId;
                element.DateCreate = model.CreationDate;
                element.DateImplement = model.CompletionDate;
                element.Status = model.Status;
                element.ProductId = model.ProductId;
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
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new AbstractStoreDatabase())
            {
                return context.Orders
                .Include(rec => rec.Product)
                .Where(rec => model == null || rec.Id == model.Id
                || (model.DateFrom.HasValue && model.DateTo.HasValue
                && rec.DateCreate >= model.DateFrom.Value
                && rec.DateCreate <= model.DateTo.Value)
                || model.ClientId.HasValue && model.ClientId == rec.ClientId
                || model.FreeOrders.HasValue && model.FreeOrders.Value
                && !rec.ImplementerId.HasValue || model.ImplementerId.HasValue
                && rec.ImplementerId == model.ImplementerId
                && rec.Status == OrderStatus.Выполняется)
                .Select(rec => new OrderViewModel
                {
                    ClientId = rec.ClientId,
                    ClientLogin = rec.Client.Login,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.Implementer.ImplementerFIO,
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
