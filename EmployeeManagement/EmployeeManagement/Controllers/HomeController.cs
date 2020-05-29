using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly ILogger<HomeController> logger;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository, ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            this.logger = logger;
        }

        // Retrieve employee name and return
        [Route("Home")]
        [Route("")]
        [Route("Home/Index")]
        [AllowAnonymous]
        public ViewResult Index()
        {
            return View();
        }


        [Route("Home/Details/{id}")]
        public ViewResult Details(int id)
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");
            //throw new Exception("fuck");
            Employee employ = _employeeRepository.GetEmployee(id);
            if (employ == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }


            Homedetail hd = new Homedetail()
            {
                Emp = employ,
                PageTitle = "Employee Details"

            };

            return View(hd);


        }
        [Route("Home/Create")]
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }
        [HttpPost]
        [Route("Home/Create")]
        public IActionResult Create(Employee emp)
        {
          Employee c=  _employeeRepository.Add(emp);

            return View();
        }

        [Route("Home/Delete")]
        [HttpGet]
        public ViewResult Delete()
        {

            return View();
        }

        [Route("Home/Delete")]
        [HttpPost]
        public ViewResult Delete(string email)
        {
            _employeeRepository.Delete(email);

            return View();
        }
        [Route("Home/Update")]
        [HttpGet]
        public ViewResult Update()
        {

            return View();
        }

        [Route("Home/Update")]
        [HttpPost]
        public ViewResult Update(Employee updatedinfo)
        {
            _employeeRepository.Update(updatedinfo);

            return View();
        }
        [Route("Home/Employeebyid")]
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Employeebyid()
        {

            return View();
        }

        [Route("Home/Employeebyid/")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Employeebyid(Employee emp)
        {
          var model=  _employeeRepository.GetEmployee(emp.Id); 
            if(model!=null)
            {
               return RedirectToAction("FinalResult", "Home", model);
            }

            return View(model);
        }
        [Route("Home/FinalResult")]
        public ViewResult FinalResult(Employee model)
        {

            return View(model);
        }


    }
}
