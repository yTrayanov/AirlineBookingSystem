using AirlineBookingSystem.Common;
using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Services;
using AirlineBookingSystem.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AirlineBookingSystem.Tests
{
    public class FlightServiceTests:BaseTest
    {
        private FlightService _flightService;

        public FlightServiceTests(DatabaseFixture fixture) : base(fixture)
        {
            this._flightService = new FlightService(fixture.Context);
        }

        [Theory]
        [MemberData(nameof(FlightData.ValidFlightData), MemberType =typeof(FlightData))]
        public void CreateFlightWithValidData(string airlineName , string originAiportName , string destinationAiportName , string year , string month , string day , string flightId)
        {
            Flight flight = this._flightService.CreateFlight(airlineName, originAiportName, destinationAiportName, year, month, day, flightId);

            Airline airline = this.Context.Airlines.FirstOrDefault(a => a.Name == airlineName);

            Assert.Contains(flight, this.Context.Flights);
            Assert.Contains(flight, airline.Flights);
        }

        [Theory]
        [MemberData(nameof(FlightData.InvalidFlightData) , MemberType =typeof(FlightData))]
        public void CreateFlightWithInvalidData(string airlineName, string originAiportName, string destinationAiportName, string year, string month, string day, string flightId)
        {
            Assert.Throws<ArgumentException>(
                () => this._flightService.CreateFlight(airlineName, originAiportName, destinationAiportName, year, month, day, flightId));
        }


        [Theory]
        [InlineData(ConstantTestData.FlightId , ConstantTestData.AirlineName)]
        public void GetFlightByIdAndAirline_WIthValidData(string flightId , string airlineName)
        {
            Flight flight = this._flightService.GetFlightByIdAndAirline(flightId, airlineName);

            Assert.Equal(flightId, flight.Id);
        }
    }
}
