using OxyPlot;
using ProjectMobileApp.Helpers;
using ProjectMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMobileApp.ViewModel
{
    public class GraphViewModel
    {
        public string info;

        public ICollection<GraphItem> Items;

        PaymentService service;
        List<Payment> payments;

        public GraphViewModel()
        {
            double food = 0;
            double clothing = 0;
            double education = 0;
            double leisure = 0;
            double other = 0;
            double transport = 0;

            service = new PaymentService();

            payments = new List<Payment>();

            List<Payment> p = service.getPayments();

            foreach (var data in p)
            {
                if (data.user.Equals(Settings.Username))
                {
                    payments.Add(data);
                }

            }

            foreach (var data in payments)
            {
                switch(data.category)
                {
                    case Category.Food:
                        food++;
                        break;
                    case Category.Clothing:
                        clothing++;
                        break;
                    case Category.Education:
                        education++;
                        break;
                    case Category.Leisure:
                        leisure++;
                        break;
                    case Category.Other:
                        other++;
                        break;
                    case Category.Transport:
                        transport++;
                        break;
                }
            }

            List<GraphItem> GraphItems = new List<GraphItem>();

            GraphItems.Add(new GraphItem() { Label = "Food", Value = food, Color = OxyColor.FromRgb(122,122,122) });
            GraphItems.Add(new GraphItem() { Label = "Clothing", Value = clothing, Color = OxyColor.FromRgb(122, 122, 122) });
            GraphItems.Add(new GraphItem() { Label = "Education", Value = education, Color = OxyColor.FromRgb(122, 122, 122) });
            GraphItems.Add(new GraphItem() { Label = "Leisure", Value = leisure, Color = OxyColor.FromRgb(122, 122, 122) });
            GraphItems.Add(new GraphItem() { Label = "Other", Value = other, Color = OxyColor.FromRgb(122, 122, 122) });
            GraphItems.Add(new GraphItem() { Label = "Transport", Value = transport, Color = OxyColor.FromRgb(122, 122, 122) });

            Items = GraphItems;
            info = "Proof of concept Graph";
        }

    }
}
