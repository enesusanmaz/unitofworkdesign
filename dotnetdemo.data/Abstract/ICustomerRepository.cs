using System;
using System.Collections.Generic;
using dotnetdemo.data.Entities;

namespace dotnetdemo.data.Abstract {
    public interface ICustomerRepository : IDisposable {
        IEnumerable<Customer> GetCustomers ();
        Customer GetCustomerByID (int customerId);
        void InsertCustomer (Customer customer);
        void DeleteCustomer (int customerId);
        void UpdateCustomer (Customer customer);
        void Save ();
    }
}