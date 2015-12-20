using Nimble.Data.Infrastructure;
using Nimble.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Data.Repository
{
  
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }


        public IEnumerable<Employee> GetEmployee()
        {

            var Employee = this.GetAll();

           
            return Employee.ToList();
        }
    }

    public interface IEmployeeRepository : IRepository<Employee>
    {
      
        IEnumerable<Employee> GetEmployee();
        
    }

}
