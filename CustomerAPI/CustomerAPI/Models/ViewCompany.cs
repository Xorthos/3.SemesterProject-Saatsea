using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL.Models;

namespace CustomerAPI.Models
{
    public class ViewCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNr { get; set; }
        public virtual List<Employee> Employees { get; set; }
        [Required]
        public bool Active { get; set; }
        public string AccessString { get; set; }
    }
}