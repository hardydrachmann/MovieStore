using System.ComponentModel.DataAnnotations;

namespace MovieStoreDAL
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Price (Dkk)")]
        public double Price { get; set; }
        [Display(Name = "Release Year")]
        public int Year { get; set; }
        [Display(Name = "Image")]
        public string ImageURL { get; set; }
        [Display(Name = "Trailer")]
        public string TrailerURL { get; set; }
        public string Genre { get; set; }
    }
}
