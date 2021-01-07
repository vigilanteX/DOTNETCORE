using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> ilogger;

        public ErrorController(ILogger<ErrorController> ilogger)
        {
            this.ilogger = ilogger;
        }



        [Route("Error/StatusOfError/{statuscode}")]
        public IActionResult StatusOfError(int statuscode)
        {
            return View(statuscode);
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =
               HttpContext.Features.Get<IExceptionHandlerPathFeature>();

             ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            ilogger.LogError("Error Message");

            return View("ErrorStack");

        }

    }

  
}
