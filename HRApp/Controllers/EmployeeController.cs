using Microsoft.AspNetCore.Mvc;
using HRApp.Models;

namespace HRApp.Controllers
{
    public class EmployeeController : Controller
    {
        HRDatabaseContext dbContext = new HRDatabaseContext();
        public IActionResult Index()
        {
            //List<Employee> employees = dbContext.Employees.ToList();
            var employees = (from employee in dbContext.Employees
                             join departmnt in dbContext.Departments on employee.DepartmentId equals departmnt.DepartmentId
                             select new Employee
                             {
                                 EmployeeId = employee.EmployeeId,
                                 EmployeeName = employee.EmployeeName,
                                 EmployeeNumber = employee.EmployeeNumber,
                                 DOB = employee.DOB,
                                 HiringDate = employee.HiringDate,
                                 GrossSalary = employee.GrossSalary,
                                 NetSalary = employee.NetSalary,
                                 DepartmentId = employee.DepartmentId,
                                 DepartmentName = departmnt.DepartmentName
                             }).ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("Department");
            ModelState.Remove("DepartmentName");
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View();
        }

        public IActionResult Edit(int Id)
        {
            Employee data = this.dbContext.Employees.Where(e => e.EmployeeId == Id).FirstOrDefault();
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("Create", data);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("Department");
            ModelState.Remove("DepartmentName");
            if (ModelState.IsValid)
            {
                dbContext.Employees.Update(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("Create",model);
        }

        public IActionResult Delete(int Id)
        {
            Employee data = this.dbContext.Employees.Where(e => e.EmployeeId == Id).FirstOrDefault();
            if(data != null)
            {
                dbContext.Remove(data);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
