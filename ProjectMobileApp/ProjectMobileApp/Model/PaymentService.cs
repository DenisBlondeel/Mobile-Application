using ProjectMobileApp.Database;
using System;
using System.Collections.Generic;

namespace ProjectMobileApp.Model
{
    public class PaymentService
    {
        // Parameters
        private PaymentDb payments;

        // Constructors
        public PaymentService() : this("InMemory") { }
        public PaymentService(String dbType)
        {
            DbFactory dbf = new DbFactory();
            payments = dbf.GetDatabase(dbType);
        }

        // Methods
        public void AddPayment(Payment payment)
        {
            payments.AddPayment(payment);
        }
        public List<Payment> getPayments()
        {
            return payments.GetPayments();
        }
        public Payment GetPayment(int id)
        {
            return payments.GetPayment(id);
        }
        public void UpdatePayment(Payment payment)
        {
            payments.UpdatePayment(payment);
        }
        public void DeletePayment(int id)
        {
            payments.DeletePayment(id);
        }
    }
}
