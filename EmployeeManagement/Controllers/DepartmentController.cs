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

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentHelper _departmentHelper;

        public DepartmentController(DepartmentHelper departmentHelper)
        {
            this._departmentHelper = departmentHelper;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var departmentData = _departmentHelper.Select_DepartmentDetails();
            return View(departmentData);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var departmentData = _departmentHelper.Select_DepartmentDetails_ByID(id);
            return View(departmentData);
        }

        // GET: DepartmentController/Create
        public ActionResult Create() => View();

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentModel departmentModel)
        {
            _departmentHelper.Insert(departmentModel);
            return RedirectToAction("Index");
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var departmentData = _departmentHelper.Select_DepartmentDetails_ByID(id);
            return View(departmentData);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentModel departmentModel)
        {
            _departmentHelper.Update(departmentModel);
            return RedirectToAction("Index");
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var departmentData = _departmentHelper.Select_DepartmentDetails_ByID(id);
            return View(departmentData);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _departmentHelper.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
