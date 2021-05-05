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

            Assert.True(this.Context.Airports.ContainsKey(name));
            Assert.Equal(this.Context.Airports[name], airport);

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
        public void GetAiportByNameWithValidAirports(string name)
        {
            Airport airport = this._airportService.GetAirportByName(name);

            Assert.Equal(name, airport.Name);
        }
    }
}
