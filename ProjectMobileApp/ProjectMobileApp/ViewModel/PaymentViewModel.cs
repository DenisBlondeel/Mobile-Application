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


        public String NameError { get; set; }
        public String DateError { get; set; }
        public String CategoryError { get; set; }
        public String AmountError { get; set; }

        //public ICommand AddPaymentCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return CurrentPayment.Name; }
            set
            {
                try
                {
                    CurrentPayment.Name = value;
                    NotifyPropertyChanged("Name");
                    NameError = "";
                }
                catch (Exception e)
                {
                    if (e is DomainException || e is DbException)
                    {
                        NameError = e.Message;
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
                    NotifyPropertyChanged("Date");
                }
                catch (Exception e)
                {
                    if (e is DomainException || e is DbException)
                    {
                        DateError = e.Message;
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
                    NotifyPropertyChanged("Category");
                }
                catch (Exception e)
                {
                    if (e is DomainException || e is DbException)
                    {
                        CategoryError = e.Message;
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
                    NotifyPropertyChanged("Amount");
                }
                catch (Exception e)
                {
                    if (e is DomainException || e is DbException)
                    {
                        AmountError = e.Message;
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

        public PaymentViewModel()
        {
            Service = new PaymentService();
            CurrentPayment = new Payment();
            //AddPaymentCommand = new AddPaymentCommand(this);
            NameError = "";
            DateError = "";
            CategoryError = "";
            AmountError = "";
        }

        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));

            // https://stackoverflow.com/questions/51780188/the-event-command-canexecutechanged-can-only-appear-on-the-left-hand-side-of
            // Change canexecute
            //((Command)AddPaymentCommand).ChangeCanExecute();
        }

    }
}
