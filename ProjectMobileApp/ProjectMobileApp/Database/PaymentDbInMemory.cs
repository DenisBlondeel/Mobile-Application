using ProjectMobileApp.Model;
using System.Collections.Generic;

namespace ProjectMobileApp.Database
{
    public class PaymentDbInMemory : PaymentDb
    {
        // Parameters
        private List<Payment> payments;

        // Constructor
        public PaymentDbInMemory()
        {
            payments = new List<Payment>();
        }

        // Methods
        public void AddPayment(Payment payment)
        {
            foreach (Payment p in payments)
            {
                if (p.Id == payment.Id)
                {
                    throw new DbException($"The id for his payment ({payment.Id}) already exists.");
                }
            }
            payments.Add(payment);
        }
        public List<Payment> GetPayments()
        {
            return payments;
        }
        public Payment GetPayment(int id)
        {
            foreach (Payment p in payments)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            throw new DbException($"Payment with id {id} was not found.");
        }
        public void UpdatePayment(Payment payment)
        {
            payments[payments.IndexOf(GetPayment(payment.Id))] = payment;
        }
        public void DeletePayment(int id)
        {
            payments.Remove(GetPayment(id));
        }
    }
}
