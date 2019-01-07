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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            MessagingCenter.Subscribe<LoginViewModel, int>(this, "login", (sender, arg) => {
                if (arg == 200)
                {
                    GoToOverviewPage();
                }
                else if (arg == 500)
                {
                    DisplayAlert("Error", "Something went wrong, try again", "ok");
                }
            });

            InitializeComponent ();
        }

        async void GoToRegisterPage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        void GoToOverviewPage()
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}