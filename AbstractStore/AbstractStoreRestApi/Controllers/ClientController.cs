using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbstractStoreRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _logic;
        public ClientController(IClientLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password) =>
        _logic.Read(new ClientBindingModel { Login = login, Password = password })?[0];

        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }
}