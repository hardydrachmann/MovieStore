using MovieStoreDAL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        private MovieRepository movRepo = new MovieRepository();
        private CustomerRepository cusRepo = new CustomerRepository();
        private OrderRepository ordRepo = new OrderRepository();

        // GET: Movie
        public ActionResult Index()
        {
            return View(movRepo.GetAll());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = movRepo.Get(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // Checkout (id)
        public ActionResult Checkout(int id)
        {
            Movie movie = movRepo.Get(id);
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
            Movie movie = movRepo.Get(movieId);

            IEnumerable<Customer> customers = cusRepo.GetAll();
            foreach (var customer in customers)
            {
                if (eMail == customer.Email)
                {
                    Order order = new Order() {
                        Date = "" + DateTime.Now.Date,
                        CustomerId = customer.Id,
                        MovieId = movieId
                    };
                    ordRepo.Add(order);                    
                    return View(movie);
                }
            }
            return Redirect("~/Movie/Checkout/" + movieId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                movRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
