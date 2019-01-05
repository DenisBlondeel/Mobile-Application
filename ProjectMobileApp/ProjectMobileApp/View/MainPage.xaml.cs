using ProjectMobileApp.Helpers;
using ProjectMobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectMobileApp.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new PaymentViewModel();
        }


        //async void GoToOverviewPage (Object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Overview());
        //}

        async void GoToOverviewPage (Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OverviewPage());
        }

        //async void GoToGraphPage(Object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Graph());
        //}

        void Logoutt(Object sender, EventArgs e)
        {
            Settings.Username = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

    }
}