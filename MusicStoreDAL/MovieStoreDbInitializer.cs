using MovieStoreDAL.DomainModels;
using System.Collections.Generic;
using System.Data.Entity;

namespace MovieStoreDAL.Initializer
{
    public class MovieStoreDbInitializer : DropCreateDatabaseAlways<MovieStoreDbContext>
    {
        private List<Customer> Customers = new List<Customer>()
        {
            new Customer() { FirstName = "Rasmus", LastName="Nielsen",
                StreetName ="Jyllandsgade", StreetNumber=52, ZipCode=6700,
                Email ="rasmniel@gmail.com", Country="Denmark"
            },

            new Customer() { FirstName = "Hardy", LastName="Drachmann",
                StreetName ="Stormgade", StreetNumber=18, ZipCode=6700,
                Email ="hardydrachmanb@phoebuscartel.dk", Country="Denmark"
            },
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

        protected override void Seed(MovieStoreDbContext context)
        {
            List<Movie> Movies = new List<Movie>()
            {
                new Movie() { Title="Bloodsport", Year=1983, Price=150,
                    ImageURL ="https://images.rapgenius.com/77ce1bab38b4efec4250aae81d7c579d.680x1000x1.jpg",
                    TrailerURL ="https://www.youtube.com/watch?v=8CLz2Hh9uqM",
                    Genres = new List<Genre>() { Genres[0], Genres[3] }
                },

                new Movie() { Title="Mars Attacks", Year=1996, Price=100,
                    ImageURL ="http://vignette3.wikia.nocookie.net/voiceacting/images/7/74/Mars_Attacks_DVD_Cover.jpg/revision/latest?cb=20130517084655",
                    TrailerURL ="https://www.youtube.com/watch?v=VYHeZCEFwhI",
                    Genres = new List<Genre>() { Genres[3], Genres[4] }
                }
            };

            context.Customers.AddRange(Customers);
            context.Genres.AddRange(Genres);
            context.Movies.AddRange(Movies);

            base.Seed(context);
        }

        public static void Initialize()
        {
            Database.SetInitializer(new MovieStoreDbInitializer());
        }
    }
}
