using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreBE
{
    public class Movie
    {
        [Display(Name = "Movie Number")]
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Release Year")]
        public int Year { get; set; }

        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        [Display(Name = "Trailer")]
        public string TrailerURL { get; set; }

        public virtual List<Genre> Genres { get; set; }
    }
}
