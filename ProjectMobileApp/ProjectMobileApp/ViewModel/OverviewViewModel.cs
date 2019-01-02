using ProjectMobileApp.Database;
using ProjectMobileApp.Helpers;
using ProjectMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

            getListFromUser();
        }

        public OverviewViewModel(string sorted):this()
        {
            switch (sorted)
            {
                case "price":
                    List<Payment> priceList = payments.OrderBy(o => o.amount).ToList();
                    payments = priceList;
                    getListFromUser();
                    break;

                case "date":
                    List<Payment> dateList = payments.OrderBy(o => o.date).ToList();
                    payments = dateList;
                    getListFromUser();
                    break;
            }
        }

        public void getListFromUser()
        {
            p = new ObservableCollection<Payment>();

            foreach (var data in payments)
            {
                if (data.user.Equals(Settings.Username))
                {
                    p.Add(data);
                }

            }
        }

    }
}
