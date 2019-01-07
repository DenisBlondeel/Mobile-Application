using Cells;
using Commands;
using Plugin.SimpleAudioPlayer;
using ProjectMobileApp.Helpers;
using ProjectMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
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

        public Cell<Uri> ImageUri { get; }
        public Cell<bool> ImageVisible { get; }
        public Cell<bool> LoadingVisible { get; }

        public PaymentService Service;

        public ISimpleAudioPlayer player;

        public bool Namechanged;

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

            this.ImageUri = Cell.Create(new Uri("http://cdn.entropiaplanets.com/w/images/4/4b/Replace-me.png"));
            this.ImageVisible = Cell.Create(true);
            this.LoadingVisible = Cell.Derived(ImageVisible, i => !i);

            Category.ValueChanged += PlayCategorySound;
            Name.ValueChanged += () => { Namechanged = true; };
            MakeImageRequest();

            var enabled = Cell.Derived(new List<Cell<string>> { NameError, DateError, CategoryError, AmountError }, cs => cs.All(c => c == ""));
            this.AddPaymentCommand = new AddPaymentCommand(this, enabled);

            player = CrossSimpleAudioPlayer.Current;

        }

        public async void MakeImageRequest()
        {
            if (!this.Namechanged) return;
            Namechanged = false;
            this.ImageVisible.Value = false;
            Uri result = new Uri("https://byvincent.nl/wp-content/themes/consultix/images/no-image-found-360x260.png");

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "931f1d87184c4a868ccd07fbf35cda25");

            // Request parameters
            queryString["q"] = this.Name.Value;
            queryString["count"] = "1";
            queryString["offset"] = "0";
            queryString["mkt"] = "en-us";
            queryString["safeSearch"] = "Strict";
            var uri = "https://api.cognitive.microsoft.com/bing/v7.0/images/search?" + queryString;
            try
            {
                var response = await client.GetAsync(uri);
                if (response?.Content != null && response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var toBeSearched = "\"contentUrl\": \"";
                    if (responseString.IndexOf(toBeSearched) >= 0)
                    {
                        string s = responseString.Substring(responseString.IndexOf(toBeSearched) + toBeSearched.Length);
                        string url = s.Substring(0, s.IndexOf('\"'));
                        url = url.Replace("\\", "");
                        Console.WriteLine(url);
                        Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out result);
                    }
                    else
                    {
                        Console.WriteLine("No image found");
                    }
                }
                else
                {
                    Console.WriteLine("failed to fetch image: " + response?.StatusCode);
                }
            } catch (Exception e)
            {
                Console.WriteLine("connection timed out");
            }
            ImageVisible.Value = true;
            ImageUri.Value = result;
        }

        private void PlayCategorySound()
        {
            if (player.IsPlaying)
            {
                return;
            }

            player.Load(Category.Value.ToString().ToLower() + ".mp3");
            player.Play();
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
                Payment p = new Payment(Name.Value, Date.Value, Category.Value, double.Parse(Amount.Value), Settings.Username);
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
