using AbstractJewerlyStoreBusinessLogic.Enums;
using AbstractJewerlyStoreFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AbstractJewerlyStoreFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string JewerlyFileName = "Jewerly.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string ProductFileName = "Product.xml";
        private readonly string ProductJewerlyFileName = "ProductComponent.xml";
        private readonly string ClientFileName = "Client.xml";
        public List<Client> Clients { get; set; }
        public List<Jewerly> Jewerlies { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductJewerly> ProductJewerlies { get; set; }
        private FileDataListSingleton()
        {
            Jewerlies = LoadJewerlies();
            Orders = LoadOrders();
            Products = LoadProducts();
            ProductJewerlies = LoadProductComponents();
            Clients = LoadClients();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveJewerlies();
            SaveOrders();
            SaveProducts();
            SaveProductJewerlies();
            SaveClients();
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FIO = elem.Element("FIO").Value,
                        Login = elem.Element("Login").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }
        private List<Jewerly> LoadJewerlies()
        {
            var list = new List<Jewerly>();
            if (File.Exists(JewerlyFileName))
            {
                XDocument xDocument = XDocument.Load(JewerlyFileName);
                var xElements = xDocument.Root.Elements("Jewerly").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Jewerly
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        JewerlyName = elem.Element("JewerlyName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Product> LoadProducts()
        {
            var list = new List<Product>();
            if (File.Exists(ProductFileName))
            {
                XDocument xDocument = XDocument.Load(ProductFileName);
                var xElements = xDocument.Root.Elements("Product").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Product
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductName = elem.Element("ProductName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<ProductJewerly> LoadProductComponents()
        {
            var list = new List<ProductJewerly>();
            if (File.Exists(ProductJewerlyFileName))
            {
                XDocument xDocument = XDocument.Load(ProductJewerlyFileName);
                var xElements = xDocument.Root.Elements("ProductJewerly").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new ProductJewerly
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                        JewerlyId = Convert.ToInt32(elem.Element("JewerlyId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }        private void SaveJewerlies()
        {
            if (Jewerlies != null)
            {
                var xElement = new XElement("Jewerlies");
                foreach (var component in Jewerlies)
                {
                    xElement.Add(new XElement("Jewerly",
                    new XAttribute("Id", component.Id),
                    new XElement("JewerlyName", component.JewerlyName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(JewerlyFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("ProductId", order.ProductId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveProducts()
        {
            if (Products != null)
            {
                var xElement = new XElement("Products");
                foreach (var product in Products)
                {
                    xElement.Add(new XElement("Product",
                    new XAttribute("Id", product.Id),
                    new XElement("ProductName", product.ProductName),
                    new XElement("Price", product.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ProductFileName);
            }
        }        private void SaveProductJewerlies()
        {
            if (ProductJewerlies != null)
            {
                var xElement = new XElement("ProductComponents");
                foreach (var productComponent in ProductJewerlies)
                {
                    xElement.Add(new XElement("ProductComponent",
                    new XAttribute("Id", productComponent.Id),
                    new XElement("ProductId", productComponent.ProductId),
                    new XElement("JewerlyId", productComponent.JewerlyId),
                    new XElement("Count", productComponent.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ProductJewerlyFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("FIO", client.FIO),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)));
                }
            }
        }
    }
}
