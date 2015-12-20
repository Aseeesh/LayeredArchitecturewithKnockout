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
    

     public interface ISalaryService
    {
        IEnumerable<Salary> GetSalarys();
        //  IEnumerable<Salary> GetActiveSalary();

        Salary GetSalary(int id);
        void CreateSalary(Salary Salary);
        void EditSalary(Salary SalaryToEdit);
        void DeleteSalary(int id);
        void SaveSalary();
        //  IEnumerable<Salary> SearchSalary(string Salary);

    }

    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository SalaryRepository;
        private readonly IUnitOfWork unitOfWork;

        public SalaryService(ISalaryRepository SalaryRepository, IUnitOfWork unitOfWork)
        {
            this.SalaryRepository = SalaryRepository;
            this.unitOfWork = unitOfWork;
        }


        #region ISalaryService Members
        public IEnumerable<Salary> GetSalarys()

        {
            var Salary = SalaryRepository.GetSalary();
            return Salary;
        }


        //public IEnumerable<Salary> GetActiveSalary()
        //{
        //    var Salary = SalaryRepository.GetMany(g => (g.Status == true));
        //    return Salary;
        //}
        //public IEnumerable<Salary> SearchSalary(string Salary)
        //{
        //    return SalaryRepository.GetMany(g => g.LinkText.ToLower().Contains(Salary.ToLower()) && g.Status == true).OrderBy(g => g.Id);
        //}
        public Salary GetSalary(int id)
        {
            var Salary = SalaryRepository.GetById(id);
            return Salary;
        }
        public void CreateSalary(Salary Salary)
        {
            SalaryRepository.Add(Salary);
            SaveSalary();
        }
        public void DeleteSalary(int id)
        {
            var Salary = SalaryRepository.GetById(id);
            SalaryRepository.Delete(Salary);
            SaveSalary();
        }
        public void EditSalary(Salary SalaryToEdit)
        {
            SalaryRepository.Update(SalaryToEdit);
            SaveSalary();
        }
        public void SaveSalary()
        {
            unitOfWork.Commit();
        }

        #endregion
    }

}
