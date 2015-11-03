using MovieStoreDAL;
using MovieStoreDAL.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MovieStoreAdminUI.Models;
using MovieStoreDAL.DomainModels;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        private MovieRepository movRepo = new MovieRepository();
        private GenreRepository genRepo = new GenreRepository();

        // GET: Movie
        public ActionResult Index(string genre)
        {
            MovieViewModel model = new MovieViewModel();
            model.Genres = genRepo.GetAll();
            IEnumerable<Movie> movies = movRepo.GetAll();
            if (genre != null && genre.Length > 0)
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
            Movie movie = movRepo.Get(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
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
                movRepo.Add(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = movRepo.Get(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllGenres = genRepo.GetAll();
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
                movRepo.Edit(movie);
            }
            return RedirectToAction("Index");
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = movRepo.Get(id);
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
            movRepo.Remove(id);
            return RedirectToAction("Index");
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
