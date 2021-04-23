namespace AirlineBookingSystem.Tests
{
    using AirlineBookingSystem.Models;
    using AirlineBookingSystem.Services;
    using AirlineBookingSystem.Tests.Fixtures;
    using AirlineBookingSystem.Tests.TestData;
    using System;
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

            Assert.Contains(airline, this.Context.Airlines);

            this.Context.Airlines.Remove(airline);
        }

        [Theory]
        [MemberData(nameof(AirlineData.InvalidAirlineData), MemberType = typeof(AirlineData))]
        public void CreatingAirlineWithInvalidData(string airlineName)
        {
            Assert.Throws<ArgumentException>(
                () => this._airlineService.CreateAirline(airlineName));
        }

        [Theory]
        [MemberData(nameof(AirlineData.ValidAirlineData) , MemberType = typeof(AirlineData))]
        public void GetAirlineByName_ReturnsCorrectAirline(string name)
        {
            

            Airline airline = this._airlineService.CreateAirline(name);

            Assert.Same(airline, this._airlineService.GetAirlineByName(name));

            this.Context.Airlines.Remove(airline);
        }

    }
}
