using ProjectMobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMobileApp.View
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
          
        public RegisterPage()
        {
           

            MessagingCenter.Subscribe<RegisterViewModel, int>(this, "registering",(sender, arg) => {

                if(arg == 200)
                {
                    DisplayAlert("Success", "Succesfully registered", "ok");
                    Navigation.PushAsync(new LoginPage());
                }
                else if(arg == 500)
                {
                    DisplayAlert("Error", "Account already exists", "ok");
                }
            });
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }
}