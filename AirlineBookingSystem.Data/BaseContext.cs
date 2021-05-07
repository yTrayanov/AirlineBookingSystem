namespace AirlineBookingSystem.Data
{
    using AirlineBookingSystem.Models;
    using System.Collections.Generic;

    public abstract class BaseContext
    {
        protected BaseContext()
        {
            this.Airlines = new Dictionary<string, Airline>();
            this.Airports = new Dictionary<string, Airport>();
            this.Flights = new Dictionary<string,Flight>();
        }

        public Dictionary<string,Airport> Airports { get; set; }

        public Dictionary<string,Airline> Airlines { get; set; }

        public Dictionary<string ,Flight> Flights { get; set; }

    }
}
