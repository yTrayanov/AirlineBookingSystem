namespace AirlineBookingSystem.Tests.Fixtures
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
    using AirlineBookingSystem.Tests.Constants;
    using System;

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
            Airport originAirport = new Airport(TestConstants.OriginAirport);

            Airport destinationAirport = new Airport(TestConstants.DestionationAirport);

            Airline airline = new Airline(TestConstants.AirlineName);

            Flight flight = new Flight(airline, originAirport, destinationAirport, new DateTime(3000, 12, 1), TestConstants.FlightId);

            Flight fullFlight = new Flight(airline, originAirport, destinationAirport, new DateTime(3000, 12, 1), TestConstants.FullFlight);

            fullFlight.Sections.Add(SeatClass.first.ToString() ,new FlightSection(TestConstants.FlightSectionRows, TestConstants.FlightSectionColumns, SeatClass.first));

            FlightSection section = new FlightSection(TestConstants.FlightSectionRows, TestConstants.FlightSectionColumns, SeatClass.first);


            flight.Sections.Add(SeatClass.first.ToString(),section);
            airline.Flights.Add(flight);

            section.Seats[TestConstants.FlightSectionRows - 1, TestConstants.FlightSectionColumns - 1].IsBooked = true;

            this.Context.Airports.Add(originAirport.Name,originAirport);

            this.Context.Airports.Add(destinationAirport.Name ,destinationAirport);

            this.Context.Airlines.Add(airline.Name,airline);

            this.Context.Flights.Add(flight.Id,flight);
            this.Context.Flights.Add(fullFlight.Id, fullFlight);

        }

        public void Dispose()
        {
            this.Context.Airlines.Clear();
            this.Context.Airports.Clear();
            this.Context.Flights.Clear();
        }
    }
}
