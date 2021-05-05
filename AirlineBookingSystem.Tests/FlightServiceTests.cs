namespace AirlineBookingSystem.Tests
{
    using AirlineBookingSystem.Common;
    using AirlineBookingSystem.Models;
    using AirlineBookingSystem.Services;
    using AirlineBookingSystem.Tests.Fixtures;
    using AirlineBookingSystem.Tests.TestData;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Xunit;

    public class FlightServiceTests:BaseTest
    {
        private FlightService _flightService;

        public FlightServiceTests(DatabaseFixture fixture) : base(fixture)
        {
            this._flightService = new FlightService(fixture.Context);
        }

        [Theory]
        [MemberData(nameof(FlightData.ValidFlightData), MemberType =typeof(FlightData))]
        public void CreateFlightWithValidData(string airlineName , string originAiportName , string destinationAiportName , int year , int month , int day , string flightId)
        {
            Flight flight = this._flightService.CreateFlight(airlineName, originAiportName, destinationAiportName, year, month, day, flightId);

            Airline airline = this.Context.Airlines[airlineName];

            Assert.True(this.Context.Flights.ContainsKey(flightId));
            Assert.Contains(flight, airline.Flights);
        }

        [Theory]
        [MemberData(nameof(FlightData.InvalidFlightData) , MemberType =typeof(FlightData))]
        public void CreateFlightWithInvalidData(string airlineName, string originAiportName, string destinationAiportName, int year, int month, int day, string flightId)
        {
            Assert.Throws<ValidationException>(
                () => this._flightService.CreateFlight(airlineName, originAiportName, destinationAiportName, year, month, day, flightId));
        }

        [Fact]
        public void CreatingFligthWithNonExistingAirline()
        {
            Assert.Throws<ArgumentException>(() =>
            this._flightService.CreateFlight("Invalid", ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, 2050, 9, 6, "123"));
        }

        [Fact]
        public void AddExistingFlight()
        {
            Assert.Throws<ArgumentException>(() =>
            this._flightService.CreateFlight(ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, 3000, 12, 1, ConstantTestData.FlightId));
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
