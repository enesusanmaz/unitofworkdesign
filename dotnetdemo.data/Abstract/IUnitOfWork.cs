using dotnetdemo.data.Entities;

namespace dotnetdemo.data.Abstract {
    public interface IUnitOfWork {
        IBaseRepository<Customer> CustomerRepository { get; }

        IBaseRepository<Order> OrderRepository { get; }
        void Commit ();

        void Dispose();
    }
}