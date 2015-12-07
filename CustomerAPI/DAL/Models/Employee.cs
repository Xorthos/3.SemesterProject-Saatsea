using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Rank { get; set; }
        [Required]
        public string Phone { get; set; }
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Company Company { get; set; }
        [Required]
        public bool Active { get; set; }
   
        public virtual List<Log> Logs { get; set; }
    }
}
