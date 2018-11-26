using System;

namespace ProjectMobileApp.Model
{
    public class Payment
    {
        private static int IdIncrement = 0;
        public int Id { get; set; }
        private string name;
        private DateTime date { get; set; }
        private Category category { get; set; }
        private double amount { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new DomainException($"{nameof(value)} must not be empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public DateTime Date
        {
            get { return this.date; }
            set
            {
                if (value >= DateTime.Now)
                {
                    //throw new DomainException($"The date has to be in the past.");
                }
                else
                {
                    this.date = value;
                }
            }
        }
        public Category Category
        {
            get { return this.category; }
            set
            {
                if (this.category != value)
                {
                    this.category = Category;
                }
                else
                {
                    //throw new DomainException($"The Category of this Payment is already equal to {value.ToString()}");
                }
            }
        }
        public double Amount
        {
            get { return this.amount; }
            set
            {
                if (value > 0)
                {
                    this.amount = value;
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
            : this("Name", DateTime.Now, Category.Food, 1.0)
        {
        }
        public Payment(String name, DateTime date, Category category, double amount)
            : this(getNewId(), name, date, category, amount)
        {
        }
        public Payment(int id, String name, DateTime date, Category category, double amount)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
            this.Category = category;
            this.Amount = amount;
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
