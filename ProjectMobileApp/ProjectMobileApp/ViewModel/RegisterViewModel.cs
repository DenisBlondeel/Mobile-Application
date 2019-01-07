using Cells;
using Commands;
using ProjectMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Cell = Cells.Cell;

namespace ProjectMobileApp.ViewModel
{
    public class RegisterViewModel
    {

        public ApiServices _apiServices;

        public Cell<string> Email { get; }

        public Cell<string> Password { get; }

        //public Cell<string> ConfirmPassword { get; }

        public Cell<string> EmailError { get; }

        public Cell<string> PasswordError { get; }

        //public Cell<string> ConfirmPasswordError { get; }

        public CellCommand RegisterCommand { get; }

        public Cell<bool> IsBusy { get; }

        public RegisterViewModel()
        {
            _apiServices = new ApiServices();

            this.Email = Cell.Create("example@example.com");
            this.Password = Cell.Create("testt");
            // this.ConfirmPassword = Cell.Create("testt");

            this.EmailError = Cell.Derived(Email, validateEmail);
            this.PasswordError = Cell.Derived(Password, validatePassword);
            // this.ConfirmPassword = Cell.Derived(Password, validateConfirmPassword);

            var enabled = Cell.Derived(new List<Cell<string>> { EmailError, PasswordError }, cs => cs.All(c => c == ""));
            this.RegisterCommand = new RegisterCommand(this, enabled);
            this.IsBusy = Cell.Create(false);

        }

        public const string MatchEmailPattern =
          @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
   + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
   + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
   + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        private string validateEmail(string email)
        {
            if (email.Length == 0)
            {
                return "email can not be empty";
            }
            else if (email.Length > 0)
            {
                if (Regex.IsMatch(email, MatchEmailPattern))
                {
                    return "";
                }
                else
                {
                    return "Invalid Email";
                }
            }
            else
            {
                /*if (AccountExists(email).Result)
                {
                    return "account already exists";
                }*/
                return "";
            }
        }

        private bool AccountExists(string email)
        {
            return _apiServices.userExists(email).Result;
        }

        private static string validatePassword(string password)
        {
            if (password.Length < 5)
            {
                return "Password must be at least 5 characters long";
            }
            else
            {
                return "";
            }
        }

        /* private  string validateConfirmPassword(string password)
         {
             if (password.Equals(ConfirmPassword.Value))
             {
                 return "Confirm password must match password";
             }
             else
             {
                 return "";
             }
         }*/

        internal async void Register()
        {
            this.IsBusy.Value = true;
            bool isSuccess = await _apiServices.RegisterAsync(Email.Value, Password.Value, "");
            this.IsBusy.Value = false;


            if (isSuccess)
            {
                MessagingCenter.Send(this, "registering", 200);
            }
            else
            {
                MessagingCenter.Send(this, "registering", 500);
            }
        }
    }

    public class RegisterCommand : CellCommand
    {

        private RegisterViewModel rvm;
        public RegisterCommand(RegisterViewModel rvm, Cell<bool> isEnabled) : base(isEnabled)
        {
            this.rvm = rvm;
        }

        public override void Execute(object parameter)
        {
            Console.WriteLine("Registering");
            rvm.Register();
        }
    }
}
