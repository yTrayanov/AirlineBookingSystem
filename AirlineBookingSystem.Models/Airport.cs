namespace AirlineBookingSystem.Models
{
    using AirlineBookingSystem.Common;
    using System;
    using System.Text.RegularExpressions;

    public class Airport
    {
        private string _name;

        public Airport(string airportName)
        {
            this.Name = airportName;
        }
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value.Length != ModelConstants.AirportNameLength || value.ToUpper() != value)
                {
                    throw new ArgumentException("Flight name must consist of 3 alphabetic upper cased characters");
                }
                if (!Regex.Match(value, ModelConstants.NamePattern).Success)
                {
                    throw new ArgumentException("Name should contain only uppercased letters!");
                }

                this._name = value;
            }
        }
    }
}
