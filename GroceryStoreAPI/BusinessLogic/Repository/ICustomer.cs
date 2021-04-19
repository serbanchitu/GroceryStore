using System.Collections.Generic;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.BusinessLogic.Repository
{
    public interface ICustomer
    {
       
        IEnumerable<Customer> GetAllCustomers();
    
        Customer GetCustomerById(int customerId);
        
        IEnumerable<Customer> AddCustomer(Customer customer);
        
        IEnumerable<Customer> UpdateCustomer(Customer customer);
    }
}
