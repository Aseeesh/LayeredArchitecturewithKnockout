using Nimble.Data.Infrastructure;
using Nimble.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Data.Repository
{
  
    public class SalaryRepository : RepositoryBase<Salary>, ISalaryRepository
    {

        public SalaryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }


        public IEnumerable<Salary> GetSalary()
        {

            var Salary = this.GetAll();

           
            return Salary.ToList();
        }
    }

    public interface ISalaryRepository : IRepository<Salary>
    {
      
        IEnumerable<Salary> GetSalary();
    }

}
