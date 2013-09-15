using A_ust.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A_ust.Workers
{
    public class FeatureWorker :BaseWorker
    {
        public FeatureWorker(AustContext _db)
        {
            if (_db == null)
                _db = new AustContext();
            this.db = _db;
        }
    }
}