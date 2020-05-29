using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Please Check Email Address")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
    }
}
