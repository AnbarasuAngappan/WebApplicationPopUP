using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationPopUP.Models;

namespace WebApplicationPopUP.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext employeeContext = new EmployeeContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Details(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = employeeContext.dbSetemployee.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }


        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeContext.dbSetemployee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = employeeContext.dbSetemployee.Find(id);
            employeeContext.dbSetemployee.Remove(employee);
            employeeContext.SaveChanges();
            return RedirectToAction("EmployeeList");
        }


        public ActionResult Popupview(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                EmployeeContext employeeContext1 = new EmployeeContext();
                Employee employeefind = employeeContext1.dbSetemployee.Find(id);
                if(employeefind == null)
                {
                    return HttpNotFound();
                }

                return View(employeefind);
            }
            
        }

        public ActionResult EmployeeList()
        {
            try
            {
                List<Employee> employees = employeeContext.dbSetemployee.ToList();
                return View(employees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }


        public ActionResult Popup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopupPost([Bind(Include = "EmployeeID,EmployeeName,EmployeeAge,EmployeeGender,EmployeeCity,EmpDepartmentID,DepartmentID")] Employee employee)
        {

            //using (var entity = new EmployeeContext())
            //{
            //    var user = User.Identity.Name;
            //    var orderSummary = entity.dbSetemployee.ToList();
            //    //var viewModel = new OrderViewModel
            //    //{
            //    //    OrderSummary = orderSummary
            //    //};

            //    return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            //}

            try
            {
                if (ModelState.IsValid)
                {
                    employeeContext.dbSetemployee.Add(employee);
                    employeeContext.SaveChanges();
                    return RedirectToAction("EmployeeList");
                }

                return View(employee);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
            
        }



    }
}