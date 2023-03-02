using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeePayroll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUserBL iuserBL;
        public EmployeeController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        //public IActionResult Index()
        //{
        //    List<EmployeeModel> objList= new List< EmployeeModel >();
        //    objList = iuserBL.
        //    return View();
        //}

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel empModel)
        {
            if(ModelState.IsValid)
            {
                iuserBL.AddEmployee(empModel);
                return RedirectToAction("AddEmployee");
            }
            else
            {
                return View(empModel);
            }
        }
    }
}
