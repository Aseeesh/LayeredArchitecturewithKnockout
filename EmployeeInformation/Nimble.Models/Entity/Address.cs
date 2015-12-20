using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Models.Entity
{
   public class Address
    {
        public int Id { get; set; }
        public string  PermanentCountry { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentState { get; set; }
        public string PermanentStreet { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentState { get; set; }
        public string CurrentStreet { get; set; }
        public int EmpId { get; set; }
        public Employee Employee { get; set; }
    }
}
