using AbstractStoreListImplement.Models;
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
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> Messages { get; set; }
        private DataListSingleton()
        {
            Jewerlies = new List<Jewerly>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductJewerlies = new List<ProductJewerly>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            Messages = new List<MessageInfo>();
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
