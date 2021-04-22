using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Data
{
    public abstract class BaseContext
    {

        protected BaseContext()
        {
            this.Airlines = new List<Airline>();
            this.Airports = new List<Airport>();
            this.Flights = new List<Flight>();
        }

        public List<Airport> Airports { get; set; }

        public List<Airline> Airlines { get; set; }

        public List<Flight> Flights { get; set; }

    }
}
