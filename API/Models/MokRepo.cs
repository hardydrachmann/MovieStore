using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStoreDAL;
using MovieStoreDAL.DomainModels;
using WebGrease.Css.Extensions;

namespace API.Models
{
    public class MokRepo : IRepository<Movie>
    {
        List<Movie> Movies = new List<Movie>()
            {
                new Movie() { Title="Bloodsport", Year=1983, Price=150,
                    ImageURL ="https://images.rapgenius.com/77ce1bab38b4efec4250aae81d7c579d.680x1000x1.jpg",
                    TrailerURL ="https://www.youtube.com/watch?v=8CLz2Hh9uqM",
                    Genres = new List<Genre>()
                },


                new Movie() { Title="Mars Attacks", Year=1996, Price=100,
                    ImageURL ="http://vignette3.wikia.nocookie.net/voiceacting/images/7/74/Mars_Attacks_DVD_Cover.jpg/revision/latest?cb=20130517084655",
                    TrailerURL ="https://www.youtube.com/watch?v=VYHeZCEFwhI",
                    Genres = new List<Genre>()
                }
            };

        private List<Genre> Genres = new List<Genre>()
        {
            new Genre() { Name="Action" },
            new Genre() { Name="Horror" },
            new Genre() { Name="Thriller" },
            new Genre() { Name="Sci-Fi" },
            new Genre() { Name="Comedy" },
            new Genre() { Name="Adventure" }
        };

        public void Add(Movie entity)
        {
            Movies.Add(entity);
        }

        public void Dispose()
        {

        }

        public void Edit(Movie entity)
        {

        }

        public Movie Get(int id)
        {
            foreach (var movie in Movies)
            {
                if (movie.Id == id)
                    return movie;
            }
            return null;
        }

        public IEnumerable<Movie> GetAll()
        {
            return Movies;
        }

        public void Remove(int id)
        {

        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return Genres;
        }
    }
}