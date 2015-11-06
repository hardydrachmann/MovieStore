using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieStoreDAL;
using API.Models;
using MovieStoreDAL.Repositories;

namespace API.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly MovieRepository movieRepo = new MovieRepository();

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetAllMovies()
        {
            return movieRepo.GetAll();
        }

        /// <summary>
        /// Get movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Movie GetMovie(int id)
        {
            Movie movie = movieRepo.Get(id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return movie;
        }

        /// <summary>
        /// Add movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public HttpResponseMessage PostMovie(Movie movie)
        {
            movieRepo.Add(movie);
            return Request.CreateResponse(HttpStatusCode.Created, movie);
        }

        /// <summary>
        /// Update movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public HttpResponseMessage PutMovie(Movie movie)
        {
            movieRepo.Edit(movie);
            return Request.CreateResponse(HttpStatusCode.Accepted, movie);
        }

        /// <summary>
        /// Delete movie
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMovie(int id)
        {
            movieRepo.Remove(id);
        }
    }
}