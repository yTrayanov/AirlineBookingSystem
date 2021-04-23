using AirlineBookingSystem.Common;
using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AirlineBookingSystem.Tests.Fixtures
{
    public class DatabaseFixture :IDisposable
    {
        public DatabaseFixture()
        {
            this.Context = AirlineBookingTestContext.GetContext();
            InsertPermanentData();
        }

        public BaseContext Context { get; set; }

       

        private void InsertPermanentData()
        {
            Airport originAirport = new Airport(ConstantTestData.OriginAirport);

            Airport destinationAirport = new Airport(ConstantTestData.DestionationAirport);

            Airline airline = new Airline(ConstantTestData.AirlineName);

            Flight flight = new Flight(airline, originAirport, destinationAirport, new DateTime(3000, 12, 1), ConstantTestData.FlightId);

            FlightSection section = new FlightSection(ConstantTestData.FlightSectionRows, ConstantTestData.FlightSectionColumns, SeatClass.first);

            flight.Sections.Add(section);
            airline.Flights.Add(flight);

            section.Seats[ConstantTestData.FlightSectionRows - 1, ConstantTestData.FlightSectionColumns - 1].IsBooked = true;

            this.Context.Airports.Add(originAirport);

            this.Context.Airports.Add(destinationAirport);

            this.Context.Airlines.Add(airline);

            this.Context.Flights.Add(flight);

        }

        public void Dispose()
        {
            this.Context.Airlines.Clear();
            this.Context.Airports.Clear();
            this.Context.Flights.Clear();
        }
    }
}
