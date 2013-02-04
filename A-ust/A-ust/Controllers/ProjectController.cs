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
    public class ProjectController : Controller
    {
        //
        // GET: /Project/

        public ActionResult Index()
        {
            return View((new ProjectWorker()).GetAllProject());
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(int id = 0)
        {
            Projects projects;
            using (ProjectWorker pw = new ProjectWorker())
            {
                projects = pw.GetProject(id);
            }
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Project/Create

        [HttpPost]
        public ActionResult Create(Projects projects)
        {
            if (ModelState.IsValid)
            {
                if ((new ProjectWorker()).AddProject(projects))
                    return RedirectToAction("Index");
                else
                    return HttpNotFound();
            }
            return View(projects);
        }

        //
        // GET: /Project/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Projects projects = (new ProjectWorker()).GetProject(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        public ActionResult Edit(Projects projects)
        {
            if (ModelState.IsValid)
            {
                if ((new ProjectWorker()).UpdateProject(projects))
                    return RedirectToAction("Index");
                else
                    return HttpNotFound();
            }
            return View(projects);
        }

        //
        // GET: /Project/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Projects projects = (new ProjectWorker()).GetProject(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        //
        // POST: /Project/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if ((new ProjectWorker()).DeleteProject(id))
                return RedirectToAction("Index");
            else
                return HttpNotFound();
        }


    }
}