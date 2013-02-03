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
    public class AssumptionsController : Controller
    {
        private AustContext db = new AustContext();

        //
        // GET: /Assumptions/

        public ActionResult Index()
        {
            return View(db.Assumptions.ToList());
        }

        //
        // GET: /Assumptions/Details/5

        public ActionResult Details(int id = 0)
        {
            Assumptions assumptions = db.Assumptions.Find(id);
            if (assumptions == null)
            {
                return HttpNotFound();
            }
            return View(assumptions);
        }

        //
        // GET: /Assumptions/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Assumptions/Create

        [HttpPost]
        public ActionResult Create(Assumptions assumptions)
        {
            if (ModelState.IsValid)
            {
                db.Assumptions.Add(assumptions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assumptions);
        }

        //
        // GET: /Assumptions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Assumptions assumptions = db.Assumptions.Find(id);
            if (assumptions == null)
            {
                return HttpNotFound();
            }
            return View(assumptions);
        }

        //
        // POST: /Assumptions/Edit/5

        [HttpPost]
        public ActionResult Edit(Assumptions assumptions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assumptions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assumptions);
        }

        //
        // GET: /Assumptions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Assumptions assumptions = db.Assumptions.Find(id);
            if (assumptions == null)
            {
                return HttpNotFound();
            }
            return View(assumptions);
        }

        //
        // POST: /Assumptions/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Assumptions assumptions = db.Assumptions.Find(id);
            db.Assumptions.Remove(assumptions);
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