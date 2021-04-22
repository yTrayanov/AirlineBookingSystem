using AirlineBookingSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Models
{
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
                if(value.Contains(" "))
                {
                    throw new ArgumentException("Airline name can't contain whitespaces");
                }

                this._name = value;
            }
        }

        public List<Flight> Flights { get; set; }
    }
}
