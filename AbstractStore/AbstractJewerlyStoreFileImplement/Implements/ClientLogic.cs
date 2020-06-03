﻿using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractJewerlyStoreFileImplement.Models;
using System.Linq;

namespace AbstractJewerlyStoreFileImplement.Implements
{
    class ClientLogic : IClientLogic
    {
        private readonly FileDataListSingleton source;

        public ClientLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client element = source.Clients.FirstOrDefault(rec => rec.Login
            == model.Login && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клинет с таким логином");
            }
            if (model.Id.HasValue)
            {
                element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
            }
            else
            {
                int maxId = source.Clients.Count > 0 ? source.Clients.Max(rec => rec.Id) : 0;
                element = new Client { Id = maxId + 1 };
                source.Clients.Add(element);
            }
            element.FIO = model.FIO;
            element.Login = model.Login;
            element.Password = model.Password;
        }

        public void Delete(ClientBindingModel model)
        {
            Client element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Clients.Remove(element);
            }
            else
            {
                throw new Exception("Клиент не найден");
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            return source.Clients
           .Where(rec => model == null || rec.Id == model.Id)
           .Select(rec => new ClientViewModel
           {
               Id = rec.Id,
               FIO = rec.FIO,
               Login = rec.Login,
               Password = rec.Password
           })
           .ToList();
        }
    }
}
