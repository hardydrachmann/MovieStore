using MovieStoreBE;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieStoreDAL
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieStoreDbContext db = new MovieStoreDbContext();

        public void Add(Movie entity)
        {
            db.Movies.Add(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Edit(Movie entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Movie Get(int id)
        {
            return db.Movies.FirstOrDefault(mov => mov.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public void Remove(int id)
        {
            var mov = Get(id);
            db.Movies.Remove(mov);
            db.SaveChanges();
        }

        public void Remove(Movie entity)
        {
            var mov = Get(entity.Id);
            db.Movies.Remove(mov);
            db.SaveChanges();
        }
    }
}
