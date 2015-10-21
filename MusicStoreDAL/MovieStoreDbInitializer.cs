using MovieStoreDAL.DomainModels;
using System.Collections.Generic;
using System.Data.Entity;

namespace MovieStoreDAL.Initializer
{
    public class MovieStoreDbInitializer : DropCreateDatabaseAlways<MovieStoreDbContext>
    {
        private List<Customer> Customers = new List<Customer>()
        {
            new Customer() {FirstName = "Rasmus", LastName="Nielsen", StreetName="Jyllandsgade", StreetNumber=52, ZipCode=6700, Email="rasmniel@gmail.com", Country="Denmark" },
            new Customer() {FirstName = "Hardy", LastName="Drachmann", StreetName="Stormgade", StreetNumber=18, ZipCode=6700, Email="hardydrachmanb@phoebuscartel.dk", Country="Denmark" },
        };

        private List<Genre> Genres = new List<Genre>()
        {
            new Genre() { Name="Action" },
            new Genre() { Name="Horror" },
            new Genre() { Name="Thriller" },
            new Genre() { Name="Sci-Fi" }
        };

        protected override void Seed(MovieStoreDbContext context)
        {
            List<Movie> Movies = new List<Movie>()
            {
            new Movie() { Title="Bloodsport", Year=1983, Price=150, ImageURL="#", TrailerURL="#",
                Genres = new List<Genre>() { Genres[0], Genres[1] }  },

             new Movie() { Title="Mars Attacks", Year=1996, Price=100, ImageURL="#", TrailerURL="#",
                Genres = new List<Genre>() { Genres[1] }  }
            };

            context.Genres.AddRange(Genres);
            context.Customers.AddRange(Customers);
            context.Movies.AddRange(Movies);

            base.Seed(context);
        }

        public static void Initialize()
        {
            Database.SetInitializer(new MovieStoreDbInitializer());
        }
    }
}
