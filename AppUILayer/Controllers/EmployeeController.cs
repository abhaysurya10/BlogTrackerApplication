using DataAccessLayer;
using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

public class EmployeeController : Controller
{
    BlogDbContext db = new BlogDbContext();
    BlogInfoRepository blogOperations = new BlogInfoRepository();
    public static string user;
 
    public ActionResult BlogList()
    {
        user = (string)Session["User"];
        return View(blogOperations.GetUserBlog(user));
    }

    public ActionResult Details(string id)
    {
        BlogInfo blogInfo = db.BlogInfo.Find(id);   
        return View(blogInfo);
    }
    public ActionResult SaveBlog()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SaveBlog([Bind(Include = "BlogId,Title,Subject,DateOfCreation,BlogUrl,EmpEmailId")] BlogInfo blog)
    {
        
            blog.EmpEmailId = user;
            blogOperations.Insert(blog);
            blogOperations.Save();
            return RedirectToAction("BlogList");
        }

   
    public ActionResult Edit(string id)
    {
        BlogInfo blogInfo = blogOperations.GetBlogId(id);
        return View(blogInfo);
    }

  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "BlogId,Title,Subject,DateOfCreation,BlogUrl,EmpEmailId")] BlogInfo blogInfo)
    {
        if (ModelState.IsValid)
        {
            blogOperations.Update(blogInfo);
            blogOperations.Save();
            return RedirectToAction("BlogList");
        }
        return View(blogInfo);
    }

  
    public ActionResult Delete(string id)
    {
        BlogInfo blogInfo = blogOperations.GetBlogId(id);
        return View(blogInfo);
    }

  
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(string id)
    {
        blogOperations.Delete(id);
        blogOperations.Save();
        return RedirectToAction("BlogList");
    }
}