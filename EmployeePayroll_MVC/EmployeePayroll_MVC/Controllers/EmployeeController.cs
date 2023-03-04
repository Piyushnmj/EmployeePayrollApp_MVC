using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayroll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUserBL iuserBL;
        public EmployeeController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModel> objList = new List<EmployeeModel>();
            objList = iuserBL.GetAllEmployees().ToList();
            return View(objList);
        }

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
                return RedirectToAction("Index");
            }
            else
            {
                return View(empModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeModel empModel = iuserBL.GetEmployeeData(id);

            if (empModel == null)
            {
                return NotFound();
            }
            return View(empModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] EmployeeModel empModel)
        {
            if (id != empModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                iuserBL.UpdateEmployeeDetail(empModel);
                return RedirectToAction("Index");
            }
            return View(empModel);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel empModel = iuserBL.GetEmployeeData(id);

            if (empModel == null)
            {
                return NotFound();
            }
            return View(empModel);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel empModel = iuserBL.GetEmployeeData(id);

            if (empModel == null)
            {
                return NotFound();
            }
            return View(empModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            iuserBL.DeleteEmployeeDetail(id);
            return RedirectToAction("Index");
        }
    }
}
