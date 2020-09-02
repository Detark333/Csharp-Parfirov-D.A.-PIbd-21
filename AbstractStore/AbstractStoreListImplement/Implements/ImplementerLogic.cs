using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractStoreListImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly DataListSingleton source;

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer tempImplementer = model.Id.HasValue ? null : new Implementer { Id = 1 };
            foreach (var implementer in source.Implementers)
            {
                if (implementer.FIO == model.FIO && implementer.Id != model.Id)
                {
                    throw new Exception("Уже есть исполнитель с такими данными");
                }
                if (!model.Id.HasValue && implementer.Id >= tempImplementer.Id)
                {
                    tempImplementer.Id = implementer.Id + 1;
                }
                else if (model.Id.HasValue && model.Id == implementer.Id)
                {
                    tempImplementer = implementer;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempImplementer == null)
                {
                    throw new Exception("Исполнитель не найден");
                }
                CreateModel(model, tempImplementer);
            }
            else
            {
                source.Implementers.Add(CreateModel(model, tempImplementer));
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < source.Implementers.Count; i++)
            {
                if (source.Implementers[i].Id == model.Id.Value)
                {
                    source.Implementers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Исполнитель не найден");
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();
            foreach (var implementer in source.Implementers)
            {
                if (model != null)
                {
                    if (implementer.Id == model.Id.Value)
                    {
                        result.Add(CreateViewModel(implementer));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(implementer));
            }
            return result;
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.FIO = model.FIO;
            implementer.PauseTime = model.PauseTime;
            implementer.WorkingTime = model.WorkingTime;
            return implementer;
        }

        private ImplementerViewModel CreateViewModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                ImplementerFIO = implementer.FIO,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            };
        }
    }
}
