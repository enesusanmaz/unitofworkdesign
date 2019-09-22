using dotnetdemo.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnetdemo.data {
    public class MyAppContext : DbContext {
        public MyAppContext () {

        }

        //entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}