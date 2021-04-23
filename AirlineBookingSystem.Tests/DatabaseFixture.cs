using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Tests.TestConstants;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AirlineBookingSystem.Tests
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
            Airport originAirport = new Airport(ConstantData.OriginAirport);

            Airport destinationAirport = new Airport(ConstantData.DestionationAirport);

            Airline airline = new Airline(ConstantData.AirlineName);

            Flight flight = new Flight(airline, originAirport, destinationAirport, new DateTime(3000, 12, 1), ConstantData.FlightId);

            FlightSection section = new FlightSection(ConstantData.FlightSectionRows, ConstantData.FlightSectionColumns, SeatClass.first);

            flight.Sections.Add(section);
            airline.Flights.Add(flight);

            section.Seats[ConstantData.FlightSectionRows - 1, ConstantData.FlightSectionColumns - 1].IsBooked = true;

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
