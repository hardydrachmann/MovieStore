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
        public string SelectedCurrency { get; set; }
        public List<string> CurrencyStrings { get; private set; }

        public MovieViewModel()
        {
            CurrencyStrings = new List<string>();
            CurrencyStrings.Add("DKK");
            CurrencyStrings.Add("EUR");
            CurrencyStrings.Add("USD");
        }
    }
}