using System;

namespace ProjectMobileApp.Database
{
    public class DbException : Exception
    {
        public DbException() : base()
        {
        }
        public DbException(string message) : base(message)
        {
        }
        public DbException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
