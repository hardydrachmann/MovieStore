using MovieStoreBE;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MovieStoreCustomerUI.Infrastructure;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly ServiceGateway gateway = new ServiceGateway();

        // GET: Movie
        public ActionResult Index()
        {
            return View(gateway.GetMovies());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = gateway.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // Checkout (id)
        public ActionResult Checkout(int id)
        {
            Movie movie = gateway.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // Checkout (Email)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Completion(string eMail, int movieId)
        {
            Movie movie = gateway.GetMovie(movieId);

            IEnumerable<Customer> customers = gateway.GetCustomers();
            foreach (var customer in customers)
            {
                if (eMail == customer.Email)
                {
                    Order order = new Order() {
                        Date = "" + DateTime.Now,
                        CustomerId = customer.Id,
                        MovieId = movieId
                    };
                    gateway.CreateOrder(order);                    
                    return View(movie);
                }
            }
            return Redirect("~/Movie/Checkout/" + movieId);
        }
    }
}
