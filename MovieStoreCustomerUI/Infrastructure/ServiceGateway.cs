using MovieStoreBE;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace MovieStoreCustomerUI.Infrastructure
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

        // Movie gateway services
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
        
        // Customer gateway services
        public IEnumerable<Customer> GetCustomers()
        {
            HttpResponseMessage response = client.GetAsync("api/customers/").Result;
            var customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            HttpResponseMessage response = client.GetAsync("api/customers/" + id).Result;
            var customer = response.Content.ReadAsAsync<Customer>().Result;
            return customer;
        }

        public HttpResponseMessage CreateCustomer(Customer customer)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/customers/", customer).Result;
            return response;
        }

        public HttpResponseMessage UpdateCustomer(Customer customer)
        {
            HttpResponseMessage response = client.PutAsJsonAsync("api/customers/", customer).Result;
            return response;
        }

        public HttpResponseMessage DeleteCustomer(int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/customers/" + id).Result;
            return response;
        }
        
        // Order gateway services
        public IEnumerable<Order> GetOrders()
        {
            HttpResponseMessage response = client.GetAsync("api/orders/").Result;
            var orders = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            return orders;
        }

        public Order GetOrder(int id)
        {
            HttpResponseMessage response = client.GetAsync("api/orders/" + id).Result;
            var order = response.Content.ReadAsAsync<Order>().Result;
            return order;
        }

        public HttpResponseMessage CreateOrder(Order order)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/orders/", order).Result;
            return response;
        }

        public HttpResponseMessage UpdateOrder(Order order)
        {
            HttpResponseMessage response = client.PutAsJsonAsync("api/orders/", order).Result;
            return response;
        }

        public HttpResponseMessage DeleteOrder(int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/orders/" + id).Result;
            return response;
        }

        // Genre gateway services
        public IEnumerable<Genre> GetGenres()
        {
            HttpResponseMessage response = client.GetAsync("api/genres/").Result;
            var genres = response.Content.ReadAsAsync<IEnumerable<Genre>>().Result;
            return genres;
        }
    }
}