using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A_ust.Models;
using A_ust.Workers;

namespace A_ust.Controllers
{
    public class AssumptionsController : Controller
    {


        //
        // GET: /Assumptions/

        public ActionResult Index()
        {
            return View((new AssumptionWorker()).GetAllAssumptions());
        }

        //
        // GET: /Assumptions/Details/5

        public ActionResult Details(int id = 0)
        {
            Assumptions assumptions;
            using (AssumptionWorker aw = new AssumptionWorker())
            {
                assumptions = aw.GetAssumption(id);
            }
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
                if ((new AssumptionWorker()).AddAssumption(assumptions))
                    return RedirectToAction("Index");
                else
                    return HttpNotFound();
            }

            return View(assumptions);
        }

        //
        // GET: /Assumptions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Assumptions assumptions = (new AssumptionWorker()).GetAssumption(id);
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
                if ((new AssumptionWorker()).UpdateAssumption(assumptions))
                    return RedirectToAction("Index");
                else
                    return HttpNotFound();
            }
            return View(assumptions);
        }

        //
        // GET: /Assumptions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Assumptions assumptions = (new AssumptionWorker()).GetAssumption(id);
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
            if ((new AssumptionWorker()).DeleteAssumption(id))
                return RedirectToAction("Index");
            else
                return HttpNotFound();
        }
    }
}