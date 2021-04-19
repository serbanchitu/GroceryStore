using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GroceryStoreAPI.BusinessLogic.Repository
{

    
    public class CustomerRepository : ICustomer
    {
        #region Constructor

        private List<Customer> _customerList;
        private const string JsonFile = "customers.json";

        public CustomerRepository()
        {

            string jsonString = File.ReadAllText(JsonFile);

            Root list = JsonConvert.DeserializeObject<Root>(jsonString);

            if (list != null) _customerList = list.customers;
        }

        #endregion
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerList;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerList.FirstOrDefault(x=>x.id==customerId);
        }

        public IEnumerable<Customer> UpdateCustomer(Customer customer)
        {
            var c = _customerList.Find(x=>x.id==customer.id);

            if (c == null) return null;
            
            c.id = customer.id;
            c.name = customer.name;

            //Write the file
            UpdateJsonFile(_customerList);

            return _customerList;
        }

        public IEnumerable<Customer> AddCustomer(Customer customer)
        {

            var newCustomerId =_customerList.Max(x => x.id) + 1;
            customer.id = newCustomerId;
            _customerList.Add(customer);
            

            //Write the file
            UpdateJsonFile(_customerList);

            return _customerList;
        }

        private void UpdateJsonFile(List<Customer> customerList)
        {
            var root = new Root { customers = customerList };
            
            //write the file
            var jsonString = JsonConvert.SerializeObject(root);
            File.WriteAllText(JsonFile, jsonString);
        }
    }

    public class Root
    {
        public List<Customer> customers { get; set; }
    }
}
