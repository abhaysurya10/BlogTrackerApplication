using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppUILayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IBlogInfo blogInfo = new BlogInfoRepository();
            return View(blogInfo.GetAllBlogInfo());
        }

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminInfo admin)
        {
           BlogDbContext dALContext = new BlogDbContext();
            
            if(dALContext.AdminInfo.Any(a=>a.EmailId==admin.EmailId && a.Password==admin.Password)) 
            {
                return RedirectToAction("EmployeeList","Admin");
            }
            else
            {
                return View() ;
            }
            
        }

        public ActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeLogin(EmpInfo emp)
        {
            IEmpInfo empInfo = new EmpInfoRepository();

            if (empInfo.ValidateEmployeeLogin(emp.EmailId,emp.PassCode))
            { 
                Session.Add("User", emp.EmailId); 
                return RedirectToAction("BlogList","Employee");
            }
            else
            {
                return View();
            }
        }
    }
}