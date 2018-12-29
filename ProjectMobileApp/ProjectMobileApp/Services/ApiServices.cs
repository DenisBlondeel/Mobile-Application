using Newtonsoft.Json;
using ProjectMobileApp.Helpers;
using ProjectMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobileApp.Services
{
    class ApiServices
    {
        internal async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var user = new User
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword

            };

            var json = JsonConvert.SerializeObject(user);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://denisoftware.ddns.net:56789/addUser", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var client = new HttpClient();

            var user = new User
            {
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(user);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://denisoftware.ddns.net:56789/login", content);

            var result = response.Content.ReadAsStringAsync();

            if (result != null)
            {
                Settings.Username = result.ToString();
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}