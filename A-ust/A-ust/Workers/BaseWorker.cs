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
    public class BaseWorker : IDisposable
    {

        private AustContext _db = new AustContext();

        public BaseWorker()
        {
            if (_db == null)
                _db = new AustContext();
        }

        public BaseWorker(AustContext newContext)
        {
            db = newContext;
        }

        public AustContext db
        {
            get { return _db; }
            set { _db = value; }
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
