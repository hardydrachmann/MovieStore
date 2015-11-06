using MovieStoreDAL;
using MovieStoreDAL.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MovieStoreAdminUI.Infrastructure;
using MovieStoreAdminUI.Models;
using MovieStoreDAL.DomainModels;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        //private readonly MovieRepository movRepo = new MovieRepository();
        //private readonly GenreRepository genRepo = new GenreRepository();
        private readonly ServiceGateway gateway = new ServiceGateway();

        // GET: Movie
        public ActionResult Index(string genre)
        {
            MovieViewModel model = new MovieViewModel();
            //model.Genres = gateway.GetAllGenres();
            IEnumerable<Movie> movies = gateway.GetMovies();
            if (!string.IsNullOrEmpty(genre))
            {
                model.SelectedGenre = genre;
                movies = movies.Where(x => x.Genres.Any(y => y.Name.Equals(genre)));
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
            //model.AllGenres = gateway.GetAllGenres();
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
            //ViewBag.AllGenres = gateway.GetAllGenres();
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
