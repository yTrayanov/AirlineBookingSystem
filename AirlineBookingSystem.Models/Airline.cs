namespace AirlineBookingSystem.Models
{
    using AirlineBookingSystem.Common;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Airline
    {
        private string _name;

        public Airline(string name)
        {
            this.Name = name;
            this.Flights = new List<Flight>();
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value.Length < 1 || value.Length > ModelConstants.AirlineNameMaxLegth)
                {
                    throw new ArgumentException("Airline name is required and must be less than 6 alphabetic symbols");
                }
                if(!Regex.Match(value , ModelConstants.NamePattern).Success)
                {
                    throw new ArgumentException("Name should contain only uppercased letters!");
                }

                this._name = value;
            }
        }

        public List<Flight> Flights { get; set; }
    }
}
