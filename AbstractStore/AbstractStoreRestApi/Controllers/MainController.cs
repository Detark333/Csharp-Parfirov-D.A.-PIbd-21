using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.BuisnessLogic;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreRestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AbstractStoreRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IProductLogic _product;
        private readonly MainLogic _main;

        public MainController(IOrderLogic order, IProductLogic product, MainLogic main)
        {
            _order = order;
            _product = product;
            _main = main;
        }

        [HttpGet]
        public List<Product> GetProductList() => _product.Read(null)?.Select(rec =>
        Convert(rec)).ToList();

        [HttpGet]
        public Product GetProduct(int productId) =>
        Convert(_product.Read(new ProductBindingModel
        { Id = productId })?[0]);

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) =>
        _order.Read(new OrderBindingModel
        { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
        _main.CreateOrder(model);

        private Product Convert(ProductViewModel model)
        {
            if (model == null) return null;
            return new Product
            {
                Id = model.Id,
                ProductName = model.ProductName,
                Price = model.Price
            };
        }
    }
}
