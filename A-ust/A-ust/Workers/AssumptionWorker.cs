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
    public class AssumptionWorker : IDisposable
    {

        public void Dispose()
        {
        }

        public Boolean AddAssumption(Assumptions ass)
        {
            Boolean rv = false;
            using (AustContext db = new AustContext())
            {
                try
                {
                    db.Assumptions.Add(ass);
                    db.SaveChanges();
                    rv = true;
                }
                catch (Exception ex)
                {
                    throw new AustException(ErrorMessages.ErrorAddingAssumptions, ex);
                }

            }
            return rv;
        }

        public Assumptions GetAssumption(int id)
        {
            using (AustContext db = new AustContext())
            {
                if (id > 0 && db.Assumptions.Any(a => a.ID == id))
                    return db.Assumptions.Find(id);
                else
                    throw new AustException(ErrorMessages.AssumptionWasNotFound);
            }
        }

        public ICollection<Assumptions> GetAllAssumptions()
        {
            using (AustContext db = new AustContext())
            {
                return db.Assumptions.ToList();
            }
        }

        public Boolean UpdateAssumption(Assumptions ass)
        {
            Boolean rv = false;
            using (AustContext db = new AustContext())
            {
                try
                {
                    db.Entry(ass).State = EntityState.Modified;
                    db.SaveChanges();
                    rv = true;
                }
                catch (Exception ex)
                {
                    throw new AustException(ErrorMessages.ErrorUpdatingAssumptions, ex);
                }
            }
            return rv;
        }

        public Boolean DeleteAssumption(int id)
        {
            Boolean rv = false;
            using (AustContext db = new AustContext())
            {
                try
                {
                    Assumptions ass = db.Assumptions.Find(id);
                    db.Assumptions.Remove(ass);
                    db.SaveChanges();
                    rv = true;
                }
                catch (Exception ex)
                {
                    throw new AustException(ErrorMessages.ErrorDeletingAssumptions, ex);
                }
            }
            return rv;
        }

    }
}