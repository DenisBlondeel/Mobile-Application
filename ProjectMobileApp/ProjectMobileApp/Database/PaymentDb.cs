using ProjectMobileApp.Model;
using System.Collections.Generic;

namespace ProjectMobileApp.Database
{
    public interface PaymentDb
    {
        List<Payment> GetPayments();

        void AddPayment(Payment payment);

        Payment GetPayment(int id);

        void UpdatePayment(Payment payment);

        void DeletePayment(int id);


    }
}
