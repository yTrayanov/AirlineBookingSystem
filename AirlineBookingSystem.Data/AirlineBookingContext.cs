using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace AirlineBookingSystem.Data
{
    public class AirlineBookingContext
    {
        private static AirlineBookingContext _context = new AirlineBookingContext();
        private AirlineBookingContext()
        {
            this.Airports = new List<Airport>();
            this.Airlines = new List<Airline>();
            this.Flights = new List<Flight>();
        }
        public List<Airport> Airports { get; set; }

        public List<Airline> Airlines { get; set; }

        public List<Flight> Flights { get; set; }

        public static AirlineBookingContext GetContext()
        {
            return _context;
        }

    }
}
