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
	public partial class Overview : ContentPage
	{
		public Overview ()
		{
			InitializeComponent ();
		}

        async void GoToHomePage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void GoToGraphPage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graph());
        }
    }
}