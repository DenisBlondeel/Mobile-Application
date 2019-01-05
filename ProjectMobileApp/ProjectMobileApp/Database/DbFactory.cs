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
                    return new PaymentDbRemote();
                default:
                    return null;
            }
        }
    }
}
