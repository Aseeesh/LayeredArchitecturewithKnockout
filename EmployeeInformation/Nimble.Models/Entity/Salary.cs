using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Models.Entity
{
   public class Salary

    {
        public int Id { get; set; }
        public string Basic { get; set; }
        public string Allowance { get; set; }
        public string Communication { get; set; }
        public int EmpId { get; set; }
        public Employee Employee { get; set; }
    }
}
