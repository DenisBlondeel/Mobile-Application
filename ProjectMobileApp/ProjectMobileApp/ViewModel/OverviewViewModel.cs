using ProjectMobileApp.Database;
using ProjectMobileApp.Helpers;
using ProjectMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjectMobileApp.ViewModel
{
    public class OverviewViewModel
    {

        public List<Payment> payments { get; set; }

        public ObservableCollection<Payment> p { get; set; }

        public PaymentService service;

        public OverviewViewModel()
        {
            service = new PaymentService();

            payments = service.getPayments();

            p = new ObservableCollection<Payment>();

            foreach(var data in payments)
            {
                if(data.user.Equals(Settings.Username))
                {
                    p.Add(data);
                }
                
            }

        }

    }
}
