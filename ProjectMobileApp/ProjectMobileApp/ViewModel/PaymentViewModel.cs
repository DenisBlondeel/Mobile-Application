using Cells;
using Commands;
using ProjectMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Cell = Cells.Cell;

namespace ProjectMobileApp.ViewModel
{
    public class PaymentViewModel
    {

        public Cell<string> Name { get; }
        public Cell<DateTime> Date { get; }
        public Cell<Category> Category { get; }
        public Cell<string> Amount { get; }

        public Cell<string> NameError { get; }
        public Cell<string> DateError { get; }
        public Cell<string> CategoryError { get; }
        public Cell<string> AmountError { get; }

        public CellCommand AddPaymentCommand { get; }

        public PaymentService Service;

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
            Payment p = new Payment();
            this.Name = Cell.Create(p.name);
            this.Date = Cell.Create(p.date);
            this.Category = Cell.Create(p.category);
            this.Amount = Cell.Create(p.amount.ToString());

            this.NameError = Cell.Derived(Name, ValidateName);
            this.DateError = Cell.Derived(Date, ValidateDate);
            this.CategoryError = Cell.Derived(Category, ValidateCategory);
            this.AmountError = Cell.Derived(Amount, ValidateAmount);

            var enabled = Cell.Derived(new List<Cell<string>> { NameError, DateError, CategoryError, AmountError }, cs => cs.All(c => c == ""));
            this.AddPaymentCommand = new AddPaymentCommand(this, enabled);


        }

        private static string ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Name can not be empty";
            }

            return "";
        }

        private static string ValidateDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                return "Date can not be in the future";
            }

            return "";
        }

        private static string ValidateCategory(Category category)
        {
            return "";
        }

        private static string ValidateAmount(string amount)
        {
            if (double.TryParse(amount, out double temp))
            {

                if (temp <= 0)
                {
                    return "Amount can not be 0 or negative.";
                }
                return "";
            }
            else
            {
                return $"{amount} is not a valid number.";
            }

        }


        internal void SavePayment()
        {
            try
            {
                Payment p = new Payment(Name.Value, Date.Value, Category.Value, double.Parse(Amount.Value));
                Service.AddPayment(p);
                Application.Current.MainPage.DisplayAlert("Success!", Name.Value + " " + Date.Value + " " + Category.Value, "Cancel");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR : " + e.Message);
            }
        }




        //public String NameError
        //{
        //    get { return nameError; }
        //    set { nameError = value; OnPropertyChanged("NameError"); }
        //}

        //public String DateError
        //{
        //    get { return DateError; }
        //    set { }
        //}

        //public String CategoryError
        //{
        //    get { return CategoryError; }
        //    set { }
        //}

        //public String AmountError
        //{
        //    get { return AmountError; }
        //    set { }
        //}

        //Dictionary<string, string> Errors = new Dictionary<string, string>();


        //public Command savePaymentCommand { get; }

        //public PaymentViewModel()
        //{
        //    Service = new PaymentService();
        //    CurrentPayment = new Payment();
        //    savePaymentCommand = new Command(savePayment);
        //    Console.WriteLine(CurrentPayment.Name);
        //}

        //public string Name
        //{
        //    get { return CurrentPayment.Name; }
        //    set
        //    {

        //        try
        //        {
        //            CurrentPayment.Name = value;
        //            Errors.Remove("NameError");
        //        }
        //        catch (Exception e)
        //        {
        //            if (e is DomainException || e is DbException)
        //            {
        //                Errors["NameError"] = e.Message;
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //}

        //public DateTime Date
        //{
        //    get { return CurrentPayment.Date; }
        //    set
        //    {
        //        try
        //        {
        //            CurrentPayment.Date = value;
        //        }
        //        catch (Exception e)
        //        {
        //            if (e is DomainException || e is DbException)
        //            {
        //                Errors["DateError"] = e.Message;
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //}
        //public Category Category
        //{
        //    get { return CurrentPayment.Category; }
        //    set
        //    {
        //        try
        //        {
        //            CurrentPayment.Category = value;
        //        }
        //        catch (Exception e)
        //        {
        //            if (e is DomainException || e is DbException)
        //            {
        //                Errors["CategoryError"] = e.Message;
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //}
        //public double Amount
        //{
        //    get { return CurrentPayment.Amount; }
        //    set
        //    {
        //        try
        //        {
        //            CurrentPayment.Amount = value;
        //        }
        //        catch (Exception e)
        //        {
        //            if (e is DomainException || e is DbException)
        //            {
        //                Errors["AmountError"] = e.Message;
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //}

        

        //// INavigation Navigation;

        //void savePayment()
        //{
        //    if (Errors.Count != 0)
        //    {
        //        foreach (KeyValuePair<string, string> entry in Errors)
        //        {
        //            switch (entry.Key)
        //            {
        //                case "NameError":
        //                    NameError = entry.Value;
        //                    Console.WriteLine(NameError + " 1");
        //                    break;
        //                case "DateError":
        //                    DateError = entry.Value;
        //                    Console.WriteLine(DateError);
        //                    break;
        //                case "CategoryError":
        //                    CategoryError = entry.Value;
        //                    Console.WriteLine(CategoryError);
        //                    break;
        //                case "AmountError":
        //                    AmountError = entry.Value;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        Errors.Clear();
        //        Name = "";
        //    }
        //    else
        //    {
        //        Application.Current.MainPage.DisplayAlert("Success!", CurrentPayment.Name + " " + CurrentPayment.Date + " " + CurrentPayment.Category, "Cancel");
        //        NameError = "";
        //        //send object to internal database
        //        //Navigation.PushModalAsync;
        //    }
        //}

    }
}
