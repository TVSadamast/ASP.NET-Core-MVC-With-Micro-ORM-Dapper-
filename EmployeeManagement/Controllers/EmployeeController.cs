using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Helper;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic.CompilerServices;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeHelper _employeeHelper;

        public EmployeeController(EmployeeHelper employeeHelper)
        {
            this._employeeHelper = employeeHelper;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var employeeData = _employeeHelper.Select_EmployeeDetails();
            return View(employeeData);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employeeData = _employeeHelper.Select_EmployeeDetails_ByID(id);
            return View(employeeData);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            GetDepartmentName();            
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            employeeModel.DepartmentName = Request.Form["DepartmentName"];
            _employeeHelper.Insert(employeeModel);
            return RedirectToAction("Index");
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employeeData = _employeeHelper.Select_EmployeeDetails_ByID(id);
            GetDepartmentName();
            return View(employeeData);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeModel employeeModel)
        {
            employeeModel.DepartmentName = Request.Form["DepartmentName"];
            _employeeHelper.Update(employeeModel); 
            return RedirectToAction("Index");
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employeeData = _employeeHelper.Select_EmployeeDetails_ByID(id);
            return View(employeeData);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _employeeHelper.Delete(id);
            return RedirectToAction("Index");
        }
        public void GetDepartmentName()
        {
            List<SelectListItem> departmentNameList = new List<SelectListItem>();
            var departmentData = _employeeHelper.Select_DepartmentName();

            foreach (var data in departmentData)
            {
                departmentNameList.Add(new SelectListItem { Text = data.DepartmentName, Value = data.DepartmentID.ToString() });
            }
            ViewBag.DepartmentName = departmentNameList;
        }
    }
}
