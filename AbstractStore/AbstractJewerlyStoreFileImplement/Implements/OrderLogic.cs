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
                order.ProductId = model.ProductId;
                order.Status = model.Status;
                order.ProductId = model.ProductId;
                order.Count = model.Count;
                order.Sum = model.Sum;
                order.DateCreate = model.CreationDate;
                order.DateImplement = model.CompletionDate;
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec =>
               rec.Id) : 0;
                order = new Order { Id = maxId + 1 };
                order.ProductId = model.ProductId;
                order.Status = model.Status;
                order.Count = model.Count;
                order.Sum = model.Sum;
                order.DateCreate = model.CreationDate;
                order.DateImplement = model.CompletionDate;
                source.Orders.Add(order);
            }

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
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new OrderViewModel
            {
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
