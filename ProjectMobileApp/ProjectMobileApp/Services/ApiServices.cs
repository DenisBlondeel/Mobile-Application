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
                email = email,
                password = password,
                confirmPassword = confirmPassword

            };

            var json = JsonConvert.SerializeObject(user);

            Console.WriteLine(json);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://denisoftware.ddns.net:56789/auth/register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var client = new HttpClient();

            var user = new User
            {
                email = email,
                password = password
            };

            var json = JsonConvert.SerializeObject(user);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://denisoftware.ddns.net:56789/auth/login", content);

            
            var result = await response.Content.ReadAsStringAsync();
            var resultUser = JsonConvert.DeserializeObject<User>(result);

            if (resultUser == null)
            {
                Console.WriteLine("it gon be false");
                return false;
            }

            else
            {
                if(resultUser.email == null || resultUser.password == null)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("it gon be true");
                    Settings.Username = resultUser.email;
                    return true;
                }
            }
        }
    }
}