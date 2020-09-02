using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Enums;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreListImplement;
using AbstractStoreListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractStoreListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;
        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order { Id = 1 };
            foreach (var order in source.Orders)
            {
                if (!model.Id.HasValue && order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
                else if (model.Id.HasValue && model.Id == order.Id)
                {
                    tempOrder = order;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Заказ не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ProductId = model.ProductId;
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId.Value;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.CreationDate;
            order.DateImplement = model.CompletionDate;
            return order;
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; i++)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Заказ не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (model != null)
                {
                    if (order.Id == model.Id.Value
                     || order.DateCreate >= model.DateFrom.Value
                     && order.DateCreate <= model.DateTo.Value
                     || model.ClientId.HasValue && order.ClientId == model.ClientId
                     || model.FreeOrders.HasValue && model.FreeOrders.Value
                    || model.ImplementerId.HasValue && order.ImplementerId
                    == model.ImplementerId && order.Status == OrderStatus.Выполняется)
                    {
                        result.Add(CreateViewModel(order));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(order));
            }
            return result;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            string productName = "";
            foreach (var product in source.Products)
            {
                if (product.Id == order.ProductId)
                {
                    productName = product.ProductName;
                }
            }
            string clientLogin = "";
            foreach (var client in source.Clients)
            {
                if (client.Id == order.ClientId)
                {
                    clientLogin = client.Login;
                }
            }
            string implementerFIO = "";
            foreach (var implementer in source.Implementers)
            {
                if (implementer.Id == order.ImplementerId)
                {
                    implementerFIO = implementer.FIO;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = implementerFIO,
                ClientLogin = clientLogin,
                ProductName = productName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
