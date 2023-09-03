using ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Hoem
        public ActionResult Index()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> employees = db.GetEmployees();

            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeDBContext db = new EmployeeDBContext();
                    bool response = db.AddEmployee(employee);

                    if (response)
                    {
                        TempData["message"] = "Data has been inserted successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();

            }
            catch
            {
                return View();

            }
        }

        // Host/Edit/E001
        public ActionResult Edit(string id)
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> employees = db.GetEmployees();

            var editedEmployee = employees.Find(emp => emp.id.Trim() == id.Trim());

           
            return View(editedEmployee);
        }

        [HttpPost]
        public ActionResult Edit(string id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDBContext db = new EmployeeDBContext();
                bool response = db.UpdateEmployee(employee);

                if (response)
                {
                    TempData["message"] = "Data has been updated successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public ActionResult Delete(string id)
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> employees = db.GetEmployees();

            var deletedEmployee = employees.Find(emp => emp.id.Trim() == id.Trim());


            return View(deletedEmployee);
        }

        [HttpPost]
        public ActionResult Delete(string id, Employee employee)
        {
            EmployeeDBContext db = new EmployeeDBContext();
            bool response = db.DeleteEmployee(id);

            if (response)
            {
                TempData["message"] = "Data has been deleted successfully";
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Details(string id)
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> employees = db.GetEmployees();

            var detailEmployee = employees.Find(emp => emp.id.Trim() == id.Trim());

             
            return View(detailEmployee);
        }

    }
}