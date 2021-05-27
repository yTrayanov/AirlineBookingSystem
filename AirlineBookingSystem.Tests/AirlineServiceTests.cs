namespace AirlineBookingSystem.Tests
{
    using AirlineBookingSystem.Models;
    using AirlineBookingSystem.Services;
    using AirlineBookingSystem.Tests.Constants;
    using AirlineBookingSystem.Tests.Fixtures;
    using AirlineBookingSystem.Tests.TestData;
    using System;
    using System.ComponentModel.DataAnnotations;
    using Xunit;
    public class AirlineServiceTests : BaseTest
    {
        private AirlineService _airlineService;

        public AirlineServiceTests(DatabaseFixture fixture) : base(fixture)
        {
            this._airlineService = new AirlineService(fixture.Context);
        }

        [Theory]
        [MemberData(nameof(AirlineData.ValidAirlineData) , MemberType =typeof(AirlineData))]
        public void CreatingAirlineWithValidData(string airlineName)
        {

            Airline airline = this._airlineService.CreateAirline(airlineName);

            Assert.True(this.Context.Airlines.ContainsKey(airlineName));
            Assert.Equal(this.Context.Airlines[airlineName], airline);

            this.Context.Airlines.Remove(airlineName);
        }

        [Theory]
        [MemberData(nameof(AirlineData.InvalidAirlineNames), MemberType = typeof(AirlineData))]
        public void CreatingAirlineWithInvalidNameData(string airlineName)
        {
            Assert.Throws<ValidationException>(
                () => this._airlineService.CreateAirline(airlineName));
        }

        [Fact]
        public void AddingExistingAirline()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this._airlineService.CreateAirline(TestConstants.AirlineName);
            });
        }

    }
}
