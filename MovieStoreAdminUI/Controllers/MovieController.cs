using MovieStoreBE;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MovieStoreAdminUI.Infrastructure;
using MovieStoreAdminUI.Models;
using BLL;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly ServiceGateway gateway = new ServiceGateway();

        // GET: Movie
        public ActionResult Index(string genre, string currency)
        {
            MovieViewModel model = new MovieViewModel();
            model.Genres = gateway.GetGenres();
            IEnumerable<Movie> movies = gateway.GetMovies();
            // determine selected genre
            if (!string.IsNullOrEmpty(genre))
            {
                model.SelectedGenre = genre;
                movies = movies.Where(x => x.Genres.Any(y => y.Name.Equals(genre)));
            }
            // determine selected currency
            if (!string.IsNullOrEmpty(currency))
            {
                model.SelectedCurrency = currency;
                foreach (var movie in movies)
                {
                    movie.Price = CurrencyConverter.ConvertPrice(movie.Price, currency);
                }
            }
            else
            {
                model.SelectedCurrency = CurrencyConverter.DKK;
            }
            model.Movies = movies;
            return View(model);
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

        // GET: Movie/Create
        public ActionResult Create()
        {
            CreateMovieViewModel model = new CreateMovieViewModel();
            model.AllGenres = gateway.GetGenres();
            model.Movie = new Movie();
            return View(model);
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                gateway.CreateMovie(movie);
            }
            return RedirectToAction("Index");
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = gateway.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllGenres = gateway.GetGenres();
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                gateway.UpdateMovie(movie);
            }
            return RedirectToAction("Index");
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = gateway.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gateway.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}
