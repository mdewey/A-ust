using A_ust.Exceptions;
using A_ust.Helpers;
using A_ust.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace A_ust.Workers
{
    public class ProjectWorker : BaseWorker
    {
        public ProjectWorker(AustContext _db)
        {
            if (_db == null)
                _db = new AustContext();
            this.db = _db;
        }

        public Boolean AddProject(Projects projects)
        {
            Boolean rv = false;

            try
            {
                db.Projects.Add(projects);
                db.SaveChanges();
                rv = true;
            }
            catch (Exception ex)
            {
                throw new AustException(ErrorMessages.ErrorAddingProject, ex);
            }


            return rv;
        }

        public Projects GetProject(int id)
        {
            if (id > 0 && db.Projects.Any(a => a.ID == id))
                return db.Projects.Find(id);
            else
                throw new AustException(ErrorMessages.ProjectWasNotFound);

        }

        public ICollection<Projects> GetAllProject()
        {

            return db.Projects.ToList();

        }

        public Boolean UpdateProject(Projects project)
        {
            Boolean rv = false;

            try
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                rv = true;
            }
            catch (Exception ex)
            {
                throw new AustException(ErrorMessages.ErrorUpdatingProject, ex);
            }

            return rv;
        }

        public Boolean DeleteProject(int id)
        {
            Boolean rv = false;

            try
            {
                Projects projects = db.Projects.Find(id);
                db.Projects.Remove(projects);
                db.SaveChanges();
                rv = true;
            }
            catch (Exception ex)
            {
                throw new AustException(ErrorMessages.ErrorDeletingProject, ex);
            }

            return rv;
        }

    }
}