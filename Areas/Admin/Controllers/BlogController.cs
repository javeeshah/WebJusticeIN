using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebJusticeIN.Areas.Admin.Models;

namespace WebJusticeIN.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private JusticeInDbContext db = new JusticeInDbContext();

        public ActionResult BlogList()
        {
            //if (Session["UserName"] != null)
            return View();
            //else
            //    return RedirectToAction("Login", "Admin");
        }       

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

        public JsonResult GetBlogList()
        {
            return Json(db.blogs, JsonRequestBehavior.AllowGet);
        }
        
        
        public ActionResult BlogCreate()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BlogCreate([Bind(Include = "BlogID,BlogNumber,BlogTitle,BlogSummary,IsPublished,AuthorName,CreateDate,UpdateDate,Active")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.BlogID = Guid.NewGuid();
                db.blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("BlogList");
            }

            return View(blog);
        }

        public ActionResult BlogEdit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BlogEdit([Bind(Include = "BlogID,BlogNumber,BlogTitle,BlogSummary,IsPublished,AuthorName,CreateDate,UpdateDate,Active")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        public ActionResult BlogDelete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult BlogDeleteConfirmed(Guid id)
        {
            Blog blog = db.blogs.Find(id);
            db.blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
