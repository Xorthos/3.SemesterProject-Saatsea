using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNr { get; set; }
        public virtual List<Employee> Employees {get; set; }
        [Required]
        public bool Active { get; set; }
        public string AccessString { get; set; }

        [ForeignKey("Identity")]
        public string IdentityId { get; set; }

        public IdentityUser Identity { get; set; }

    }
}
