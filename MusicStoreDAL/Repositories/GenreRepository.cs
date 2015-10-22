using MovieStoreDAL;
using MovieStoreDAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreDAL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private MovieStoreDbContext db = new MovieStoreDbContext();

        public void Add(Genre entity)
        {
            db.Genres.Add(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Edit(Genre entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Genre Get(int id)
        {
            return db.Genres.Include(gen => gen.Movies).FirstOrDefault(gen => gen.Id == id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres.Include(gen => gen.Movies).ToList();
        }

        public void Remove(int id)
        {
            db.Genres.Remove(Get(id));
            db.SaveChanges();
        }
    }
}
