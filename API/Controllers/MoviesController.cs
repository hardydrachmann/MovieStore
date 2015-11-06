using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieStoreDAL;
using API.Models;
using MovieStoreDAL.DomainModels;

namespace API.Controllers
{
    public class MoviesController : ApiController
    {
        //private readonly MovieRepository movRepo = new MovieRepository();
        private MokRepo movRepo = new MokRepo();

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetAllMovies()
        {
            return movRepo.GetAll();
        }

        /// <summary>
        /// Get movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Movie GetMovie(int id)
        {
            Movie movie = movRepo.Get(id);
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
            movRepo.Add(movie);
            return Request.CreateResponse(HttpStatusCode.Created, movie);
        }

        /// <summary>
        /// Update movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public HttpResponseMessage PutMovie(Movie movie)
        {
            movRepo.Edit(movie);
            return Request.CreateResponse(HttpStatusCode.Accepted, movie);
        }

        /// <summary>
        /// Delete movie
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMovie(int id)
        {
            movRepo.Remove(id);
        }
    }
}