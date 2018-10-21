using ProjectMobileApp.Database;
using ProjectMobileApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectMobileApp.ViewModel
{
    public class PaymentViewModel : INotifyPropertyChanged
    {
        public PaymentService Service { get; set; }
        public Payment CurrentPayment { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void onErrorRaised(string error)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(error));
        }

        public String NameError
        {
            get { return NameError; }
            set { NameError = value; onErrorRaised("test"); }
        }

        public String DateError
        {
            get { return DateError; }
            set { }
        }

        public String CategoryError
        {
            get { return CategoryError; }
            set { }
        }

        public String AmountError
        {
            get { return AmountError; }
            set { }
        }

        Dictionary<string, string> Errors = new Dictionary<string, string>();


        public Command savePaymentCommand { get; }

        public PaymentViewModel()
        {
            Service = new PaymentService();
            CurrentPayment = new Payment();
            savePaymentCommand = new Command(savePayment);
            NameError = "";
            DateError = "";
            CategoryError = "";
            AmountError = "";
        }

        public string Name
        {
            get { return CurrentPayment.Name; }
            set
            {
                try
                {
                    CurrentPayment.Name = value;
                    NameError = "";
                }
                catch (Exception e)
                {
                    if (e is DomainException || e is DbException)
                    {
                        Errors["NameError"] = e.Message;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
        public DateTime Date
        {
            get { return CurrentPayment.Date; }
            set
            {
                try
                {
                    CurrentPayment.Date = value;
                }
                catch (Exception e)
                {
                    if (e is DomainException || e is DbException)
                    {
                        Errors["DateError"] = e.Message;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
        public Category Category
        {
            get { return CurrentPayment.Category; }
            set
            {
                try
                {
                    CurrentPayment.Category = value;
                }
                catch (Exception e)
                {
                    if (e is DomainException || e is DbException)
                    {
                        Errors["CategoryError"] = e.Message;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
        public double Amount
        {
            get { return CurrentPayment.Amount; }
            set
            {
                try
                {
                    CurrentPayment.Amount = value;
                }
                catch (Exception e)
                {
                    if (e is DomainException || e is DbException)
                    {
                        Errors["AmountError"] = e.Message;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        public List<string> Categories
        {
            get
            {
                return new List<string>(Enum.GetNames(typeof(Category)));
            }
        }

            INavigation Navigation;
        void savePayment()
        {
            if(Errors.Count != 0)
            {
                foreach (KeyValuePair<string, string> entry in Errors)
                {
                    switch (entry.Key)
                    {
                        case "NameError":
                            NameError = entry.Value;
                            break;
                        case "DateError":
                            DateError = entry.Value;
                            break;
                        case "CategoryError":
                            CategoryError = entry.Value;
                            break;
                        case "AmountError":
                            AmountError = entry.Value;
                            break;
                        default:
                            break;
                    }
                }
            }
            //Navigation.PushModalAsync;
            //send object to internal database
        }

    }
}
