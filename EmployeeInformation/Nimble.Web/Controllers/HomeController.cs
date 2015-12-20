using AutoMapper;
using Nimble.Models.Entity;
using Nimble.Services.Services;
using Nimble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nimble.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService EmployeeService;

        //   private readonly EmployeeServicesView EmployeeServicesView = new EmployeeServicesView();
        public HomeController(IEmployeeService iEmployeeService)
        {
            this.EmployeeService = iEmployeeService;
        }

       
     
        public ActionResult Index()
        {

            GetAll(); 
            return View();
        }

 
        public string Add(EmployeeViewModel EmployeeViewModel)
        {
            try
            {
                if (EmployeeViewModel != null)
                {
                     if (ModelState.IsValid)
                    {


                        Employee Employee = Mapper.Map<EmployeeViewModel, Employee>(EmployeeViewModel);

                        EmployeeService.CreateEmployee(Employee);
                        return "Record has been Added";
                    }

                    return "Record has Not be Added";
                }
                else
                {
                    return "Record has Not been Added";
                }
            }
            catch (Exception e)
            {
                return "Record has Not been Added";
            }
        }

        

        public JsonResult GetAll()
        {
            string link = "";
            // IEnumerable<EmployeeViewModel> Employees = EmployeeServicesView.GetEmployees(link, EmployeeService);
            IEnumerable<Employee> Employees = EmployeeService.GetEmployees();
            return Json(Employees, JsonRequestBehavior.AllowGet);
        }
     
        public string Update(EmployeeViewModel EmployeeViewModel)
        {
            try
            {
                if (EmployeeViewModel != null)
                {
                    if (ModelState.IsValid)
                    {

                        Employee Employee = Mapper.Map<EmployeeViewModel, Employee>(EmployeeViewModel);
                        Employee EmployeeSave = EmployeeService.GetEmployee(Employee.Id);
                        EmployeeSave.Allowance = Employee.Allowance;
                        EmployeeSave.Basic = Employee.Basic;
                        EmployeeSave.Communication = Employee.Communication;
                        EmployeeSave.CurrentCity = Employee.CurrentCity;
                        EmployeeSave.CurrentCountry = Employee.CurrentCountry;
                        EmployeeSave.CurrentState = Employee.CurrentState;
                        EmployeeSave.CurrentStreet = Employee.CurrentStreet;
                        EmployeeSave.DOB = Employee.DOB;
                        EmployeeSave.FirstName = Employee.FirstName;
                        EmployeeSave.LastName = Employee.LastName;
                        EmployeeSave.PermanentCity = Employee.PermanentCity;
                        EmployeeSave.PermanentCountry = Employee.PermanentCountry;
                        EmployeeSave.PermanentState = Employee.PermanentState;
                        EmployeeSave.PermanentStreet = Employee.PermanentStreet;
                        EmployeeService.EditEmployee(EmployeeSave);
                        return "Record has been Updated";
                    }

                    return "Record has Not be Updated";
                }
                else
                {
                    return "Record has Not been Updated";
                }
            }
            catch (Exception e)
            {
                return "Record has Not been Updated";
            }
        }

        public string Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    EmployeeService.DeleteEmployee(id);
                    return "Employee Has Been Deleted";
                }
                else
                {
                    return "Employee Hasnot Been Deleted";
                }
            }
            catch
            {
                return "Employee Hasnot Been Deleted";
            }
        }


    }
}