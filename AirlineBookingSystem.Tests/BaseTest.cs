using AirlineBookingSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Tests
{
    public abstract class BaseTest
    {

        public AirlineBookingTestContext Context = AirlineBookingTestContext.GetContext();

        public void ResetContext()
        {
            this.Context.Airlines.Clear();
            this.Context.Airports.Clear();
            this.Context.Flights.Clear();
        }

        public void ResetAirlines()
        {
            this.Context.Airlines.Clear();
        }

        public void ResetAirports()
        {
            this.Context.Airports.Clear();
        }

        public void ResetFlights()
        {
            this.Context.Flights.Clear();
        }
    }
}
