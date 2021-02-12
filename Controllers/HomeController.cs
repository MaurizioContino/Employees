using employees.Models;
using EmployeesDataService.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace employees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseManager dbManager;
        private readonly EmployeesService empserv;
        public HomeController(ILogger<HomeController> logger, DatabaseManager dbManager, EmployeesService empserv)
        {
            this.dbManager = dbManager;
            this.empserv = empserv;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (dbManager.RequireUpdate())
            {
                return RedirectToAction("index", "UpdateDB");
            }
            else
            {
                
                return View(empserv.GetList());
            }

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
