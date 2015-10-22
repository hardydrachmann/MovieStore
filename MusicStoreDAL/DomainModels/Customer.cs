using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreDAL
{
    public class Customer
    {
        [Display(Name = "Customer Number")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street")]
        public string StreetName { get; set; }

        [Display(Name = "Street Number")]
        public int StreetNumber { get; set; }

        [Display(Name = "Zip")]
        public int ZipCode { get; set; }

        public string Country { get; set; }

        [Display(Name = "E-Mail")]
        [StringLength(50)]
        public string Email { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
