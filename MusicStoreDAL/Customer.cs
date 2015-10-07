using System.ComponentModel.DataAnnotations;

namespace MovieStoreDAL
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name="First Name")]
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
        public string Email { get; set; }
    }
}
