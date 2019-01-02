using ProjectMobileApp.Helpers;
using System;

namespace ProjectMobileApp.Model
{
    public class Payment
    {
        private static int IdIncrement = 0;
        public int Id { get; set; }
        private string _name;
        private string _date { get; set; }
        private Category _category { get; set; }
        private double _amount { get; set; }
        private string _user { get; set; }

        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new DomainException($"{nameof(value)} must not be empty.");
                }
                else
                {
                    this._name = value;
                }
            }
        }

        public string user
        {
            get
            {
                return this._user;
            }
            set
            {
                this._user = value;
            }
        }
        public DateTime date
        {
            get { return Convert.ToDateTime(this._date); }
            set
            {
                if (value >= DateTime.Now)
                {
                    //throw new DomainException($"The date has to be in the past.");
                }
                else
                {
                    this._date = value.ToString();
                }
            }
        }
        public Category category
        {
            get { return this._category; }
            set
            {
                if (this._category != value)
                {
                    this._category = category;
                }
                else
                {
                    //throw new DomainException($"The Category of this Payment is already equal to {value.ToString()}");
                }
            }
        }
        public double amount
        {
            get { return this._amount; }
            set
            {
                if (value > 0)
                {
                    this._amount = value;
                }
                else
                {
                    throw new DomainException("The amount has to be a positive value.");
                }
            }
        }

        // Constructors
        //public Payment(String name, String date, String category, double amount)
        //    : this(name, ToDate(date), ToCategory(category), amount)
        //{
        //}
        public Payment()
            : this("Name", DateTime.Now, Category.Food, 1.0, Settings.Username)
        {
        }
        public Payment(String name, DateTime date, Category category, double amount, string user)
            : this(getNewId(), name, date, category, amount, Settings.Username)
        {
        }
        public Payment(int id, String name, DateTime date, Category category, double amount, string user)
        {
            this.Id = id;
            this.name = name;
            this.date = date;
            this.category = category;
            this.amount = amount;
            this.user = user;
        }

        // Static Functions
        /// <summary>
        /// Auto increment id
        /// </summary>
        /// <returns>A new id for a Payment</returns>
        public static int getNewId()
        {
            return IdIncrement++;
        }
        ///// <summary>
        ///// Parses a date in string format to date format. Throws a DomainException if invalid.
        ///// </summary>
        ///// <param name="date">A string representation of a date.</param>
        ///// <returns>A DateTime representation of the given string, if it is valid.</returns>
        //public static DateTime ToDate(String date)
        //{
        //    if (DateTime.TryParse(date, out DateTime temp))
        //    {
        //        return temp;
        //    }
        //    else
        //    {
        //        throw new DomainException($"{date} is not a valid date.");
        //    }
        //}
        ///// <summary>
        ///// Parses a Category in string format to Category format. Throws a DomainException if invalid.
        ///// </summary>
        ///// <param name="date">A string representation of a Category.</param>
        ///// <returns>A Category representation of the given string, if it is valid.</returns>
        //public static Category ToCategory(String category)
        //{
        //    if (Enum.TryParse<Category>(category, out Category temp))
        //    {
        //        return temp;
        //    }
        //    else
        //    {
        //        throw new DomainException($"{category} is not a valid category.");
        //    }
        //}
    }
}
