using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Enums;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractJewerlyStoreFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractJewerlyStoreFileImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly FileDataListSingleton source;
        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order order;
            if (model.Id.HasValue)
            {
                order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec =>
               rec.Id) : 0;
                order = new Order { Id = maxId + 1 };
                source.Orders.Add(order);
            }
            order.ProductId = model.ProductId;
            order.ClientId = model.ClientId.Value;
            order.Status = model.Status;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.DateCreate = model.CreationDate;
            order.DateImplement = model.CompletionDate;
        }
        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders
            .Where(rec => model == null || rec.Id == model.Id
            || rec.DateCreate >= model.DateFrom.Value
           && rec.DateImplement <= model.DateTo.Value
           || model.ClientId.HasValue && model.ClientId == rec.ClientId
           || model.FreeOrders.HasValue && model.FreeOrders.Value
           && !rec.ImplementerId.HasValue || model.ImplementerId.HasValue
           && rec.ImplementerId == model.ImplementerId
           && rec.Status == OrderStatus.Выполняется)
            .Select(rec => new OrderViewModel
            {
                ClientId = rec.ClientId,
                ClientLogin = source.Clients.FirstOrDefault(cl =>
                cl.Id == rec.Id)?.Login,
                Id = rec.Id,
                Count = rec.Count,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                ProductName = source.Products.FirstOrDefault((r) => r.Id == rec.ProductId).ProductName,
                ProductId = rec.ProductId,
                Status = rec.Status,
                Sum = rec.Sum
            })
            .ToList();
        }
    }
}
