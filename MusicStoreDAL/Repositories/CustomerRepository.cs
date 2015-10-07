using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreDAL
{
    public class CustomerRepository : IRepository<Customer>
    {
        private MovieStoreDbContext db = new MovieStoreDbContext();

        public void Add(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Edit(Customer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return db.Customers.Include(cus => cus.Orders).FirstOrDefault(cus => cus.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.Include(cus => cus.Orders).ToList();
        }

        public void Remove(int id)
        {
            var cus = Get(id);
            for (int i = 0; i < cus.Orders.Count; i++)
            {
                db.Orders.Remove(cus.Orders[i]);
            }

            db.Customers.Remove(cus);
            db.SaveChanges();
        }
    }
}
