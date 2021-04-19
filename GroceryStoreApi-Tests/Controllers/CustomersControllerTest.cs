using System;
using System.Collections.Generic;
using System.Text;
using GroceryStoreAPI.BusinessLogic.Repository;
using GroceryStoreAPI.Controllers;
using GroceryStoreApi_Tests.Repository;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GroceryStoreApi_Tests.Controllers
{
    public class CustomersControllerTest
    {
        private CustomersController _controller;
        private ICustomer _repository;

        public CustomersControllerTest()
        {
            _repository = new CustomerRepositoryFake();
            _controller = new CustomersController(_repository);
        }


        [Fact]
        public void GetAllCustomers_ReturnsOK()
        {
            var okResult = _controller.GetAllCustomers();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
