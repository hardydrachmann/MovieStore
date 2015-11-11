using MovieStoreBE;
using MovieStoreDAL.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class GenresController : ApiController
    {
        private readonly GenreRepository genreRepo = new GenreRepository();

        public IEnumerable<Genre> GetAllGenres()
        {
            return genreRepo.GetAll();
        }
    }
}
