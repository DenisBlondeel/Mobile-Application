using ProjectMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectMobileApp.ViewModel
{
    class LoginViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await _apiServices.LoginAsync(Email, Password);

                    if (isSuccess)
                        Message = "Successfully successful";
                    else
                    {
                        Message = "Failed";
                    }
                });
            }
        }
    }
}
