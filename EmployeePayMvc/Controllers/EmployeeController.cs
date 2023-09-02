using BussinessLayer.Services;
using CommonLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            this.employeeServices =employeeServices;
        }

        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeServices.GetAllEmployeeService().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
      
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeServices.AddEmployeeService(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
