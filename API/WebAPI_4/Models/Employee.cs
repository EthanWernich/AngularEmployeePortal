using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_4.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }

    }
}
