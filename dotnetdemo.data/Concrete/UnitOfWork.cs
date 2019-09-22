using dotnetdemo.data.Abstract;
using dotnetdemo.data.Entities;

namespace dotnetdemo.data.Concrete {
    public class UnitOfWork : IUnitOfWork {

        private MyAppContext _dbContext;
        private BaseRepository<Customer> _customers;
        private BaseRepository<Order> _orders;

        public UnitOfWork (MyAppContext dbContext) {
            _dbContext = dbContext;
        }

        public IBaseRepository<Customer> CustomerRepository {
            get {
                return _customers ??
                    (_customers = new BaseRepository<Customer> (_dbContext));
            }
        }

        public IBaseRepository<Order> OrderRepository {
            get {
                return _orders ??
                    (_orders = new BaseRepository<Order> (_dbContext));
            }
        }

        public void Commit () {
            _dbContext.SaveChanges ();
        }

        public void Dispose () {
            _dbContext.Dispose ();
        }
    }
}