﻿using ProjectMobileApp.Helpers;
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
	public partial class OverviewPage : ContentPage
	{
		public OverviewPage ()
		{
			InitializeComponent ();
            BindingContext = new OverviewViewModel();
        }

        async void GoToHomePage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void GoToGraphPage(Object sender, EventArgs e)
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