using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Models.Entity
{
   public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string DOB { get; set; }
        public string Basic { get; set; }
        public string Allowance { get; set; }
        public string Communication { get; set; }
        public string PermanentCountry { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentState { get; set; }
        public string PermanentStreet { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentState { get; set; }
        public string CurrentStreet { get; set; }
         
    }
}
