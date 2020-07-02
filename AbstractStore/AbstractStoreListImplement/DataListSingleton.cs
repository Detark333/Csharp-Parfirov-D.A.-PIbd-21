using AbstractJewerlyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractStoreListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Jewerly> Jewerlies { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductJewerly> ProductJewerlies { get; set; }
        public IEnumerable<object> Jewerly { get; internal set; }
        private DataListSingleton()
        {
            Jewerlies = new List<Jewerly>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductJewerlies = new List<ProductJewerly>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
