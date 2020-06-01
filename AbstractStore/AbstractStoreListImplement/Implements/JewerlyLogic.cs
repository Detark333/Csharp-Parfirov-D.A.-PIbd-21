using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractStoreListImplement.Implements
{
    public class JewerlyLogic : IJewerlyLogic
    {
        private readonly DataListSingleton source;
        public JewerlyLogic()
        {
            source = DataListSingleton.GetInstance();
        }        public void CreateOrUpdate(JewerlyBindingModel model)
        {
            Jewerly tempJewerly = model.Id.HasValue ? null : new Jewerly
            {
                Id = 1
            };
            foreach (var jewerly in source.Jewerlies)
            {
                if (jewerly.JewerlyName == model.JewerlyName && jewerly.Id != model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (!model.Id.HasValue && jewerly.Id >= tempJewerly.Id)
                {
                    tempJewerly.Id = jewerly.Id + 1;
                }
                else if (model.Id.HasValue && jewerly.Id == model.Id)
                {
                    tempJewerly = jewerly;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempJewerly == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempJewerly);
            }
            else
            {
                source.Jewerlies.Add(CreateModel(model, tempJewerly));
            }
        }
        public void Delete(JewerlyBindingModel model)
        {
            for (int i = 0; i < source.Jewerlies.Count; ++i)
            {
                if (source.Jewerlies[i].Id == model.Id.Value)
                {
                    source.Jewerlies.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<JewerlyViewModel> Read(JewerlyBindingModel model)
        {
            List<JewerlyViewModel> result = new List<JewerlyViewModel>();
            foreach (var component in source.Jewerlies)
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
        private Jewerly CreateModel(JewerlyBindingModel model, Jewerly component)
        {
            component.JewerlyName = model.JewerlyName;
            return component;
        }
        private JewerlyViewModel CreateViewModel(Jewerly component)
        {
            return new JewerlyViewModel
            {
                Id = component.Id,
                JewerlyName = component.JewerlyName
            };
        }
    }
}