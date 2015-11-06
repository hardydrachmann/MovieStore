using MovieStoreDAL.DomainModels;
using MovieStoreDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
