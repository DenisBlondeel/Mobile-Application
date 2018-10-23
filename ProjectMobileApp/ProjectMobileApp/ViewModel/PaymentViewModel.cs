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

        void OnPropertyChanged(string param)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(param));
        }

        string nameError = "";

        public String NameError
        {
            get { return nameError; }
            set { nameError = value; OnPropertyChanged("NameError");  }
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
            Console.WriteLine(CurrentPayment.Name);
        }

        public string Name
        {
            get { return CurrentPayment.Name; }
            set
            {

                try
                {
                    CurrentPayment.Name = value;
                    Errors.Remove("NameError");
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

           // INavigation Navigation;
     
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
                            Console.WriteLine(NameError + " 1");
                            break;
                        case "DateError":
                            DateError = entry.Value;
                            Console.WriteLine(DateError);
                            break;
                        case "CategoryError":
                            CategoryError = entry.Value;
                            Console.WriteLine(CategoryError);
                            break;
                        case "AmountError":
                            AmountError = entry.Value;
                            break;
                        default:
                            break;
                    }
                }
                Errors.Clear();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Success!", CurrentPayment.Name + " " + CurrentPayment.Date + " " + CurrentPayment.Category, "Cancel");
                //send object to internal database
                //Navigation.PushModalAsync;
            }
        }

    }
}
