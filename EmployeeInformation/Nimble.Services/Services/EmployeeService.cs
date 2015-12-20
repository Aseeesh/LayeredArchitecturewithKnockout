using Nimble.Data.Infrastructure;
using Nimble.Data.Repository;
using Nimble.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Services.Services
{
  
     public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
      //  IEnumerable<Employee> GetActiveEmployee();

        Employee GetEmployee(int id);
        void CreateEmployee(Employee Employee);
        void EditEmployee(Employee EmployeeToEdit);
        void DeleteEmployee(int id);
        void SaveEmployee();
      //  IEnumerable<Employee> SearchEmployee(string Employee);

    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository EmployeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeService(IEmployeeRepository EmployeeRepository, IUnitOfWork unitOfWork)
        {
            this.EmployeeRepository = EmployeeRepository;
            this.unitOfWork = unitOfWork;
        }


        #region IEmployeeService Members
        public IEnumerable<Employee> GetEmployees()

        {
            var Employee = EmployeeRepository.GetEmployee();
            return Employee;
        }


        //public IEnumerable<Employee> GetActiveEmployee()
        //{
        //    var Employee = EmployeeRepository.GetMany(g => (g.Status == true));
        //    return Employee;
        //}
        //public IEnumerable<Employee> SearchEmployee(string Employee)
        //{
        //    return EmployeeRepository.GetMany(g => g.LinkText.ToLower().Contains(Employee.ToLower()) && g.Status == true).OrderBy(g => g.Id);
        //}
        public Employee GetEmployee(int id)
        {
            var Employee = EmployeeRepository.GetById(id);
            return Employee;
        }
        public void CreateEmployee(Employee Employee)
        {
            EmployeeRepository.Add(Employee);
            SaveEmployee();
        }
        public void DeleteEmployee(int id)
        {
            var Employee = EmployeeRepository.GetById(id);
            EmployeeRepository.Delete(Employee);
            SaveEmployee();
        }
        public void EditEmployee(Employee EmployeeToEdit)
        {
            EmployeeRepository.Update(EmployeeToEdit);
            SaveEmployee();
        }
        public void SaveEmployee()
        {
            unitOfWork.Commit();
        }

        #endregion
    }

}
