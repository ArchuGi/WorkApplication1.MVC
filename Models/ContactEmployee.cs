using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ContactEmployee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public int EmployeeAge { get; set; }
        public string EmployeeType { get; set; }
        public string EmployeeAddress { get; set; }
        public DateTime EmployeeDate { get; set; }

    }
}
