﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreDAL
{
    class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public string ImageURL { get; set; }
        public string TrailerURL { get; set; }
        public string Genre { get; set; }
    }
}
