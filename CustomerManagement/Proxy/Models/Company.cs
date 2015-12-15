 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Proxy.Models
{
    public class Company
    {    
        public int ID { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        public int Zipcode { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telephone Number Required")]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$",
            ErrorMessage = "Entered phone format is not valid.It should be 10 digit. The valid format is 00-0000-0000!")]
        public string PhoneNr { get; set; }
        public List<Employee> Employees  { get; set; }
        public bool Active { get; set; }
        public string AccessString { get; set; }
    }
}
