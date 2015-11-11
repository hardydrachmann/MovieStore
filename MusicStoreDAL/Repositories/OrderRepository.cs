using MovieStoreBE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreDAL
{
    public class OrderRepository : IRepository<Order>
    {
        private MovieStoreDbContext db = new MovieStoreDbContext();

        public void Add(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Edit(Order entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Order Get(int id)
        {
            return db.Orders.Include(ord => ord.Movie).Include(ord => ord.Customer).FirstOrDefault(ord => ord.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(ord => ord.Movie).Include(ord => ord.Customer).ToList();
        }

        public void Remove(int id)
        {
            var ord = Get(id);
            db.Orders.Remove(ord);
            db.SaveChanges();
        }
    }
}
