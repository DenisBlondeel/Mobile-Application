using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectMobileApp.Model;

namespace ProjectMobileApp.Database
{
    class PaymentDbRemote : PaymentDb
    {
        HttpClient client;

        public PaymentDbRemote()
        {
            client = new HttpClient();

        }

        public async void AddPayment(Payment payment)
        {
            var pm = serialize(payment);

            HttpContent content = new StringContent(pm);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            await client.PostAsync("http://denisoftware.ddns.net:56789/payment", content);

        }

        public Payment GetPayment(int id)
        {
            Payment payment = GetasyncPayment(id).Result;
            return payment;
        }

        public List<Payment> GetPayments()
        {
            List<Payment> payments = GetAsyncPayments();
            return payments;
        }

        public void DeletePayment(int id)
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

        private Payment deserialise(string json)
        {
           return JsonConvert.DeserializeObject<Payment>(json);
        }

        private List<Payment> GetAsyncPayments()
        {
            var response = client.GetAsync("http://denisoftware.ddns.net:56789/payment/").Result;

            var result = response.Content.ReadAsStringAsync().Result;

            List<Payment> resultPayments = JsonConvert.DeserializeObject<List<Payment>>(result);

            return resultPayments;
        }

        private async Task<Payment> GetasyncPayment(int id)
        {
            var response = await client.GetAsync("http://denisoftware.ddns.net:56789/payment/" + id);

            var result = response.Content.ReadAsStringAsync().Result;

            Payment resultPayment = deserialise(result);

            return resultPayment;
        }

    }
}
