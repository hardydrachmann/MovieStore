using System.ComponentModel.DataAnnotations;

namespace MovieStoreDAL
{
    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        [Display(Name="Movie Id")]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Display(Name="Customer Id")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
