using A_ust.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace A_ust.Workers
{
    public class ProjectWorker : IDisposable
    {

        public void Dispose()
        {
        }

        public Boolean AddProject(Projects projects)
        {
            Boolean rv = false;
            using (AustContext db = new AustContext())
            {
                db.Projects.Add(projects);
                db.SaveChanges();
                rv = true;
            }
            return rv;
        }

        public Projects GetProject(int id)
        {
            using (AustContext db = new AustContext())
            {
                return db.Projects.Find(id);
            }
        }

        public ICollection<Projects> GetAllProject()
        {
            using (AustContext db = new AustContext())
            {
                return db.Projects.ToList();
            }
        }

        public Boolean UpdateProject(Projects project)
        {
            Boolean rv = false;
            using (AustContext db = new AustContext())
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                rv = true;
            }
            return rv;
        }

        public Boolean DeleteProject(int id)
        {
            Boolean rv = false;
            using (AustContext db = new AustContext())
            {
                Projects projects = db.Projects.Find(id);
                db.Projects.Remove(projects);
                db.SaveChanges();
                rv = true;
            }
            return rv;
        }

    }
}