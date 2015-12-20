using Nimble.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Data.Configuration
{
   
     public class SalaryConfiguration : EntityTypeConfiguration<Salary>
    {
        public SalaryConfiguration()
        {
            Property(g => g.Id).IsRequired();
            Property(g => g.Allowance).IsRequired();
            Property(g => g.Basic).IsRequired();
            Property(g => g.Communication).IsRequired();
            Property(g => g.EmpId).IsRequired();

        }
    }
}
