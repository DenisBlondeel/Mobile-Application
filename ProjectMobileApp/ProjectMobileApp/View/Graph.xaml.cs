using OxyPlot;
using OxyPlot.Series;
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
    public partial class Graph : ContentPage
    {
        public GraphViewModel plotInfo;

        public Graph()
        {
            InitializeComponent();
            plotInfo = new GraphViewModel();
            BindingContext = plotInfo;
            MakePlot();
        }

        async void GoToOverviewPage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OverviewPage());
        }

        async void GoToHomePage(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        public void MakePlot()
        {
            PlotModel pm = new PlotModel
            {
                Title = "poc",
                TextColor = OxyColor.FromRgb(122, 122, 122)
            };

            var ps = new PieSeries
            {
                StrokeThickness = .25,
                InsideLabelPosition = .25,
                AngleSpan = 360,
                StartAngle = 0,
                TextColor = OxyColor.FromRgb(100, 100, 100)
            };
            foreach(var item in plotInfo.Items)
            {
                ps.Slices.Add(new PieSlice(item.Label, item.Value) { IsExploded = false, Fill = item.Color});

            }
            pm.Series.Add(ps);
            this.plotmodel.Model = pm;

        }


    }
}