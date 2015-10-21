using System.Collections.Generic;
using System.Data.Entity;

namespace MovieStoreDAL.Initializer
{
    public class MovieStoreDbInitializer : DropCreateDatabaseAlways<MovieStoreDbContext>
    {
        private List<Customer> Customers = new List<Customer>()
        {
            new Customer() {FirstName = "Rasmus", LastName="Nielsen", StreetName="Jyllandsgade", StreetNumber=52, ZipCode=6700, Email="rasmniel@gmail.com", Country="Denmark" }
        };

        private List<Movie> Movies = new List<Movie>()
        {
            new Movie() { Title="Bloodsport", Year=1983, Price=150, ImageURL="#", TrailerURL="#", Genre="Test" }
        };

        protected override void Seed(MovieStoreDbContext context)
        {
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
