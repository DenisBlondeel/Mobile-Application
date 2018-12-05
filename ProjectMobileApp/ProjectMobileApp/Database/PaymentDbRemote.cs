using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ProjectMobileApp.Model;

namespace ProjectMobileApp.Database
{
    class PaymentDbRemote : PaymentDb
    {
        public void AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public void DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        public Payment GetPayment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPayments()
        {
            throw new NotImplementedException();
        }

        public void UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        private String serialize(Payment payment)
        {
            return JsonConvert.SerializeObject(payment, Formatting.Indented);
        }

        private Payment deserialise(String json)
        {
           return JsonConvert.DeserializeObject<Payment>(json);
        }

    }
}
