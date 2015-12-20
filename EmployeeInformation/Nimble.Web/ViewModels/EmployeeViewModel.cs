using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nimble.Web.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        public string DOB { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string Basic { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string Allowance { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string Communication { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string PermanentCountry { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string PermanentCity { get; set; }
        public string PermanentState { get; set; }
        public string PermanentStreet { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string CurrentCountry { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string CurrentCity { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string CurrentState { get; set; }
        [Required] 
        [DataType(DataType.Text)]
        public string CurrentStreet { get; set; }
    }
}