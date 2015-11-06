using MovieStoreDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;
using MovieStoreDAL.DomainModels;

namespace MovieStoreAdminUI.Infrastructure
{
    public class ServiceGateway
    {
        private HttpClient client;

        public ServiceGateway()
        {
            client = new HttpClient();
            string baseAddress =
                WebConfigurationManager.AppSettings["ApiBaseAddress"];
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
        public IEnumerable<Movie> GetMovies()
        {
            HttpResponseMessage response = client.GetAsync("api/movies/").Result;
            var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            return movies;
        }

        public Movie GetMovie(int id)
        {
            HttpResponseMessage response = client.GetAsync("api/movies/" + id).Result;
            var movie = response.Content.ReadAsAsync<Movie>().Result;
            return movie;
        }

        public HttpResponseMessage CreateMovie(Movie movie)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/movies/", movie).Result;
            return response;
        }

        public HttpResponseMessage UpdateMovie(Movie movie)
        {
            HttpResponseMessage response = client.PutAsJsonAsync("api/movies/", movie).Result;
            return response;
        }

        public HttpResponseMessage DeleteMovie(int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/movies/" + id).Result;
            return response;
        }
    }
}