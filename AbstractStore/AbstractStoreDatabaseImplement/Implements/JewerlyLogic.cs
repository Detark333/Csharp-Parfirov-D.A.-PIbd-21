
using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractStoreDatabaseImplement.Implements
{
    public class JewerlyLogic : IJewerlyLogic
    {
            public void CreateOrUpdate(JewerlyBindingModel model)
            {
                using (var context = new AbstractStoreDatabase())
                {
                    Jewerly element = context.Jewerlies.FirstOrDefault(rec => rec.JewerlyName == model.JewerlyName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть компонент с таким названием");
                    }
                    if (model.Id.HasValue)
                    {
                        element = context.Jewerlies.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                    }
                    else
                    {
                        element = new Jewerly();
                        context.Jewerlies.Add(element);
                    }
                    element.JewerlyName = model.JewerlyName;
                    context.SaveChanges();
                }
            }
            public void Delete(JewerlyBindingModel model)
            {
                using (var context = new AbstractStoreDatabase())
                {
                    Jewerly element = context.Jewerlies.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element != null)
                    {
                        context.Jewerlies.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
            }
            public List<JewerlyViewModel> Read(JewerlyBindingModel model)
            {
                using (var context = new AbstractStoreDatabase())
                {
                    return context.Jewerlies
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
    }

