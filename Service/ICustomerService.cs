﻿using SimpleRestApi.Entities;

namespace SimpleRestApi.Service
{
    public interface ICustomerService
    {
        public void CreateNewCustomer(Customer customer);

        public IEnumerable<Customer> GetAllCustomers();

        public void DeleteCustomer(int id);
        public Customer GetCustomerById(int id);
    }
}
