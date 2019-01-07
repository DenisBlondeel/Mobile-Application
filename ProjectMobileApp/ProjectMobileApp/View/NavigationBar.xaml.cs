using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMobileApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMobileApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavigationBar : ContentView
	{
		public NavigationBar ()
		{
			InitializeComponent ();
        }

        async void GoToOverview(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OverviewPage());
        }

        async void GoToAddPage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void GoToGraph(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graph());
        }

        void Logoutt(Object sender, EventArgs e)
        {
            Settings.Username = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}