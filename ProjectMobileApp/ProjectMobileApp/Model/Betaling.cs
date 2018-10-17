using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMobileApp.Model
{
    public class Betaling
    {
        public static int IDincrement = 0;
        private int ID { get; set; }
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
            }
        }

        public Betaling(String name, DateTime date, Category category, double amount)
            : this(getNewId(), name, date, category, amount)
        {
        }

        public Betaling(int id, String name, DateTime date, Category category, double amount)
        {
            this.ID = id;
            this.Name = name;
            this.Date = date;
            this.Category = category;
            this.Amount = amount;
        }

        public static int getNewId()
        {
            return ++IDincrement;
        }
    }
}
