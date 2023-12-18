using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AppUILayer.Controllers
{
    public class AdminController : Controller
    {
        readonly IEmpInfo EmpOperations = new EmpInfoRepository();
        
        public ActionResult EmployeeList()
        {
           IEnumerable<EmpInfo> emplist= EmpOperations.GetAllEmpInfo();
            return View(emplist);
        }
        

        // GET: Admin/Create
        public ActionResult SaveEmployee()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult SaveEmployee(FormCollection collection)
        {
            EmpInfo emp = new EmpInfo
            {
                EmailId = collection["EmailId"],
                Name = collection["Name"],
                DateOfJoining = DateTime.Parse(collection["DateOfJoining"]),
                PassCode = Convert.ToInt32(collection["PassCode"])
            };

            EmpOperations.Insert(emp);
            EmpOperations.Save();
            return RedirectToAction("EmployeeList");
        }

        // GET: Admin/Edit/5
        public ActionResult EditEmployee(string EmailId)
        {
            EmpInfo emp=EmpOperations.GetEmpInfo(EmailId);
            return View(emp);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditEmployee(string EmailId,FormCollection collection)
        {
                EmpInfo emp = new EmpInfo() 
                {
                    EmailId = collection["EmailId"],
                    Name = collection["Name"],
                    DateOfJoining = DateTime.Parse(collection["DateOfJoining"]),
                    PassCode = Convert.ToInt32(collection["PassCode"])
                };
                EmpOperations.Update(emp);
                EmpOperations.Save();
                return RedirectToAction("EmployeeList");
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string EmailId)
        {
            EmpInfo emp = EmpOperations.GetEmpInfo(EmailId);
            return View(emp);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(string EmailId,FormCollection collection)
        {
            EmpOperations.Delete(EmailId);
            EmpOperations.Save();
            return RedirectToAction("EmployeeList");
        }
    }
}
