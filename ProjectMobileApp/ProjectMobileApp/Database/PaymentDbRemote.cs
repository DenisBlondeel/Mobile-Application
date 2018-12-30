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

        public void DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetPayment(int id)
        {
            var response = await client.GetAsync("http://denisoftware.ddns.net:56789/payment/" + id);

            var result = response.Content.ReadAsStringAsync().Result;

            Payment resultPayment = deserialise(result);

            return resultPayment;
        }

        public async Task<List<Payment>> GetPayments()
        {
            var response = await client.GetAsync("http://denisoftware.ddns.net:56789/payment/");

            var result = response.Content.ReadAsStringAsync().Result;

            List<Payment> resultPayments = JsonConvert.DeserializeObject<List<Payment>>(result);

            return resultPayments;
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

    }
}
