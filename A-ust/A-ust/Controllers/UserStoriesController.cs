using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A_ust.Models;

namespace A_ust.Controllers
{
    public class UserStoriesController : Controller
    {
        private AustContext db = new AustContext();

        //
        // GET: /UserStories/

        public ActionResult Index()
        {
            return View(db.UserStories.ToList());
        }

        //
        // GET: /UserStories/Details/5

        public ActionResult Details(int id = 0)
        {
            UserStories userstories = db.UserStories.Find(id);
            if (userstories == null)
            {
                return HttpNotFound();
            }
            return View(userstories);
        }

        //
        // GET: /UserStories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserStories/Create

        [HttpPost]
        public ActionResult Create(UserStories userstories)
        {
            if (ModelState.IsValid)
            {
                db.UserStories.Add(userstories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userstories);
        }

        //
        // GET: /UserStories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserStories userstories = db.UserStories.Find(id);
            if (userstories == null)
            {
                return HttpNotFound();
            }
            return View(userstories);
        }

        //
        // POST: /UserStories/Edit/5

        [HttpPost]
        public ActionResult Edit(UserStories userstories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userstories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userstories);
        }

        //
        // GET: /UserStories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserStories userstories = db.UserStories.Find(id);
            if (userstories == null)
            {
                return HttpNotFound();
            }
            return View(userstories);
        }

        //
        // POST: /UserStories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserStories userstories = db.UserStories.Find(id);
            db.UserStories.Remove(userstories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}