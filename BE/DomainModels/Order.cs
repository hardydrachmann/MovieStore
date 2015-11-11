using System.ComponentModel.DataAnnotations;

namespace MovieStoreBE
{
    public class Order
    {
        [Display(Name = "Order Number")]
        public int Id { get; set; }

        public string Date { get; set; }

        [Display(Name= "Movie Number")]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Display(Name= "Customer Number")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
