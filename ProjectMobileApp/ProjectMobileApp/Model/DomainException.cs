using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMobileApp.Model
{
    class DomainException : Exception
    {
        public DomainException() : base()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
