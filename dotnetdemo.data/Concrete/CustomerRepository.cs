using System;
using System.Collections.Generic;
using System.Linq;
using dotnetdemo.data.Abstract;
using dotnetdemo.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnetdemo.data.Concrete {
    public class CustomerRepository : ICustomerRepository {
        private MyAppContext context;

        public CustomerRepository (MyAppContext context) {
            this.context = context;
        }

        public IEnumerable<Customer> GetCustomers () {
            return context.Customers.ToList ();
        }
        public Customer GetCustomerByID (int customerId) {
            return context.Customers.Find (customerId);
        }

        public void InsertCustomer (Customer customer) {
            context.Customers.Add (customer);
        }

        public void DeleteCustomer (int customerId) {
            Customer customer = context.Customers.Find (customerId);
            context.Customers.Remove (customer);
        }

        public void UpdateCustomer (Customer customer) {
            context.Entry (customer).State = EntityState.Modified;
        }

        public void Save () {
            context.SaveChanges ();
        }

        private bool disposed = false;

        protected virtual void Dispose (bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    context.Dispose ();
                }
            }
            this.disposed = true;
        }

        public void Dispose () {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

    }
}