﻿using ProjectMobileApp.ViewModel;
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

        async void OnNextPageButtonClicked (Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Overview());
        }
    }
}
