using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractJewerlyStoreFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractJewerlyStoreFileImplement.Implements
{
    public class JewerlyLogic : IJewerlyLogic
    {
        private readonly FileDataListSingleton source;
        public JewerlyLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(JewerlyBindingModel model)
        {
            Jewerly element = source.Jewerlies.FirstOrDefault(rec => rec.JewerlyName == model.JewerlyName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Jewerlies.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Jewerlies.Count > 0 ? source.Jewerlies.Max(rec => rec.Id) : 0;
                element = new Jewerly { Id = maxId + 1 };
                source.Jewerlies.Add(element);
            }
            element.JewerlyName = model.JewerlyName;
        }
        public void Delete(JewerlyBindingModel model)
        {
            Jewerly element = source.Jewerlies.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Jewerlies.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<JewerlyViewModel> Read(JewerlyBindingModel model)
        {
            return source.Jewerlies
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new JewerlyViewModel
            {
                Id = rec.Id,
                JewerlyName = rec.JewerlyName
            })
            .ToList();
        }
    }
}
