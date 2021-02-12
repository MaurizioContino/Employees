using EmployeesDataService.models;
using EmployeesDataService.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employees.Controllers
{
    public class UpdateDBController : Controller
    {
        DatabaseManager dbManager;
        public UpdateDBController(DatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UpdateDB()
        {
            try
            {
                await Task.Run(() =>
                {
                    this.dbManager.Update();
                });
                return View(new DBUpdateResult() { Success = true });
            }
            catch (Exception ex)
            {
                return View(new DBUpdateResult() { Success = false, Error = ex.Message });
            };

        }
    }
}
