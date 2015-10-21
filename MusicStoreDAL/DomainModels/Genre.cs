using System.Collections.Generic;

namespace MovieStoreDAL.DomainModels
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}
