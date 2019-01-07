using Cells;
using ProjectMobileApp.Helpers;
using ProjectMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Cell = Cells.Cell;

namespace ProjectMobileApp.ViewModel
{
    class LoginViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public Cell<bool> IsBusy { get; }

        public LoginViewModel()
        {
            this.IsBusy = Cell.Create(false);
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    this.IsBusy.Value = true;
                    var isSuccess = await _apiServices.LoginAsync(Email, Password);
                    this.IsBusy.Value = false;
                    Console.WriteLine(isSuccess);
                    
                    if (isSuccess)
                        MessagingCenter.Send(this, "login", 200);
                    else
                    {
                        MessagingCenter.Send(this, "login", 500);
                    }
                });
            }
        }
    }
}
