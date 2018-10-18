using System;

namespace ProjectMobileApp.Database
{
    public class DbFactory
    {
        public PaymentDb GetDatabase(String dbType)
        {
            if (dbType == null)
            {
                return null;
            }

            switch (dbType.ToUpper())
            {
                case "INMEMORY":
                    return new PaymentDbInMemory();
                case "SQL":
                    throw new NotImplementedException();
                default:
                    return null;
            }
        }
    }
}
