using AirlineBookingSystem.Models.Common;
using System;

namespace AirlineBookingSystem.Models
{
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

                this._name = value;
            }
        }
    }
}
