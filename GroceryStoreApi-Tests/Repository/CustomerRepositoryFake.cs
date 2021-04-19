using System.Collections.Generic;
using System.Linq;
using GroceryStoreAPI.BusinessLogic.Repository;
using GroceryStoreAPI.Models;

namespace GroceryStoreApi_Tests.Repository
{
    public class CustomerRepositoryFake : ICustomer
    {
        private readonly List<Customer> _customerList;

        public CustomerRepositoryFake()
        {
          
            //initiate the list with the data from the file
            _customerList = new List<Customer>()
            {
                new Customer{ id=1, name = "Bob"},
                new Customer{ id=2, name = "Mary"},
                new Customer{ id=3, name = "Joe"}
                
            };

        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerList;
        }


        public Customer GetCustomerById(int customerId)
        {
             return _customerList.FirstOrDefault(x => x.id == customerId);
        }

        public IEnumerable<Customer> AddCustomer(Customer customer)
        {
            var newCustomerId = _customerList.Max(x => x.id) + 1;
            customer.id = newCustomerId;
            _customerList.Add(customer);

            return _customerList;
        }
        
        
        public IEnumerable<Customer> UpdateCustomer(Customer customer)
        {
            var c = _customerList.Find(x => x.id == customer.id);

            if (c == null) return null;

            c.id = customer.id;
            c.name = customer.name;

            return _customerList;
        }

    }
}
