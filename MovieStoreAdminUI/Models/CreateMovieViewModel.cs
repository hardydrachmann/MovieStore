using MovieStoreBE;
using System.Collections.Generic;

namespace MovieStoreAdminUI.Models
{
    public class CreateMovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> AllGenres { get; set; }
    }
}