namespace AirlineBookingSystem.Tests
{
    using AirlineBookingSystem.Common;
    using AirlineBookingSystem.Models;
    using AirlineBookingSystem.Services;
    using AirlineBookingSystem.Tests.Fixtures;
    using AirlineBookingSystem.Tests.TestData;
    using System;
    using System.ComponentModel.DataAnnotations;
    using Xunit;

    public class AirportServiceTests : BaseTest
    {
        private AirportService _airportService;

        public AirportServiceTests(DatabaseFixture fixture) : base(fixture)
        {
            this._airportService = new AirportService(fixture.Context);
        }

        [Theory]
        [MemberData(nameof(AirportData.ValidAirportData) , MemberType =typeof(AirportData))]
        public void CreateAirportWithValidData(string name)
        {
            Airport airport = this._airportService.CreateAirport(name);

            Assert.Contains(airport, this.Context.Airports);

        }

        [Theory]
        [MemberData(nameof(AirportData.InvalidAirportData) , MemberType =typeof(AirportData))]
        public void CreateAirportWithInvalidData(string name)
        {
            Assert.Throws<ValidationException>(
                () => this._airportService.CreateAirport(name));
        }

        [Theory]
        [InlineData(ConstantTestData.OriginAirport)]
        [InlineData(ConstantTestData.DestionationAirport)]
        public void GetAiportByNameWithValidAirports(string airportName)
        {
            Airport airport = this._airportService.GetAirportByName(airportName);

            Assert.Equal(airportName, airport.Name);
        }
    }
}
