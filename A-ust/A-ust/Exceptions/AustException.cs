using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A_ust.Exceptions
{
    public class AustException: Exception
    {
        public AustException() { 
            
        }
        public AustException(string message) : base(message)
        { 
        }
        public AustException(string message, Exception innerException)
            : base(message, innerException) 
        { 
        }
    }
}