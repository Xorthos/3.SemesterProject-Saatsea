using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public class Log
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Company Company { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Import { get; set; }
        [Required]
        public virtual List<Employee> Employees { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
