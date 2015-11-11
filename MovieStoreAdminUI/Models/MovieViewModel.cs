using MovieStoreBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreAdminUI.Models
{
    public class MovieViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string SelectedGenre { get; set; }
    }
}