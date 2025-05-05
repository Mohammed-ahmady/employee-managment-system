using Microsoft.AspNetCore.Mvc;
using EmpApp.Models;

namespace EmpApp.Controllers;

public enum SortDirection
{
    Ascending,
    Descending   
}
public class EmployeeController : Controller
{
    HRDatabaseContext _dbcontext = new HRDatabaseContext();
    
    
    // GET
    public IActionResult Index(string sortField, string currentSortField, SortDirection sortDirection, string searchByName)
    {
        var employees = GetEmployees();
        if (!string.IsNullOrEmpty(searchByName))
            employees = employees.Where(e => e.EmployeeName.ToLower().Contains(searchByName.ToLower())).ToList();
        return View(this.sortEmployees(employees, sortField, currentSortField, sortDirection));
    }

    private List<Employee> GetEmployees()
    {
        var employees = (from employee in _dbcontext.Employees
            join department in _dbcontext.Departments on employee.DepartmentId equals department.DepartmentId
            select new Employee
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeeNumber = employee.EmployeeNumber,
                HiringDate = employee.HiringDate,
                DOB = employee.DOB,
                GrossSalary = employee.GrossSalary,
                NetSalary = employee.NetSalary,
                DepartmentId = employee.DepartmentId,
                DepartmentName = department.DepartmentName
            }).ToList();
        return employees;
    }

    public IActionResult Create()
    {
        ViewBag.Department = this._dbcontext.Departments.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee model)
    {
        ModelState.Remove("Department");
        ModelState.Remove("EmployeeId");
        ModelState.Remove("DepartmentName");
        if (ModelState.IsValid)
        {
            _dbcontext.Employees.Add(model);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Department = this._dbcontext.Departments.ToList();
        return View(model);
    }

    public IActionResult Edit(int id)
    {
        Employee data = this._dbcontext.Employees.Where( e => e.EmployeeId == id).FirstOrDefault();
        ViewBag.Department = this._dbcontext.Departments.ToList();
        return View("Create", data);
    }

    [HttpPost]
    public IActionResult Edit(Employee model)
    {
        ModelState.Remove("Department");
        ModelState.Remove("EmployeeId");
        ModelState.Remove("DepartmentName");
        if (ModelState.IsValid)
        {
            _dbcontext.Employees.Update(model);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Department = this._dbcontext.Departments.ToList();
        return View("Create", model);
    }

    public IActionResult Delete(int id)
    {
        Employee data = this._dbcontext.Employees.Where( e => e.EmployeeId == id).FirstOrDefault();
        if (data != null)
        {
            _dbcontext.Employees.Remove(data);
            _dbcontext.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    
    private List<Employee> sortEmployees(List<Employee> employees, string sortField,string currentSortField ,SortDirection sortDirection)
    {
        if (string.IsNullOrEmpty(sortField))
        {
            ViewBag.SortField = "EmployeeNumber";
            ViewBag.SortDirection = SortDirection.Ascending;
        }
        else
        {
            if (currentSortField == sortField)
            {
                ViewBag.SortDirection = sortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
            }
            else
            {
                ViewBag.SortDirection = SortDirection.Ascending;
            }
            ViewBag.SortField = sortField;
        }
        var propertyInfo = typeof(Employee).GetProperty(ViewBag.SortField);
        employees = ViewBag.SortDirection == SortDirection.Ascending ? employees.OrderBy(e => propertyInfo.GetValue(e, null)).ToList() : employees.OrderByDescending(e => propertyInfo.GetValue(e, null)).ToList();
        return employees;
    }
}