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
	public partial class NavigationBar : ContentView
	{
		public NavigationBar ()
		{
			InitializeComponent ();
        }

        async void GoToHomePage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Overview());
        }

        async void GoToAddPage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void GoToListPage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graph());
        }
    }
}