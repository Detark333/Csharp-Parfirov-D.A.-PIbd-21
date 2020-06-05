using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractJewerlyStoreBusinessLogic.ViewModels
{
    public class JewerlyViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string JewerlyName { get; set; }
    }
}
