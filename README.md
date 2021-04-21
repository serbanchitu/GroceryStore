# GroceryStore
The code does not provide UI. To add/update/display etc please use a service like Postman; 
In the real application the API database methods should be made async; The test project is not finalized - I ran out of time, but it provides a good idea/direction. 


- to Get all customers run: 
http://(server)/api/customers/getallcustomers

- to Get a specific Customer run:
http://(server)/api/customers/getCustomerById/2

- to Add customer (POST customer json object) to
http://(server)/api/addCustomer

- to Update customer(PUT a customer object) to
http://(server)/api/customers/updateCustomer


sample jSon customerObject :
{
    "id": 2,
    "name": "Mary"
}
