using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.Interfaces
{
    public interface IJewerlyLogic
    {
        List<JewerlyViewModel> Read(JewerlyBindingModel model);
        void CreateOrUpdate(JewerlyBindingModel model);
        void Delete(JewerlyBindingModel model);
    }
}
