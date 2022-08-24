using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_4
{
    public class employee
    {
        public int id { get; set; }
        [StringLength(20)]
        public string Employee { get; set; }
        public string Department { get; set; }
        public string DateOfJoining { get; set; }
    }
}
