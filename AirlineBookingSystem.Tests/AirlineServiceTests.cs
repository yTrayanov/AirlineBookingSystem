using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Services;
using AirlineBookingSystem.Tests.TestData;
using System;
using Xunit;

namespace AirlineBookingSystem.Tests
{
    public class AirlineServiceTests : BaseTest
    {
        private AirlineService _airlineService = new AirlineService(AirlineBookingTestContext.GetContext());

        [Theory]
        [MemberData(nameof(AirlineData.ValidAirlineData) , MemberType =typeof(AirlineData))]
        public void CreatingAirlineWithValidData(string airlineName)
        {

            Airline airline = this._airlineService.CreateNewAirline(airlineName);

            Assert.Contains(airline, this.Context.Airlines);

            this.Context.Airlines.Remove(airline);
        }

        [Theory]
        [MemberData(nameof(AirlineData.InvalidAirlineData), MemberType = typeof(AirlineData))]
        public void CreatingAirlineWithInvalidData(string airlineName)
        {
            Assert.Throws<ArgumentException>(
                () => this._airlineService.CreateNewAirline(airlineName));
        }

        [Theory]
        [MemberData(nameof(AirlineData.ValidAirlineData) , MemberType = typeof(AirlineData))]
        public void GetAirlineByName_ReturnsCorrectAirline(string name)
        {
            

            Airline airline = this._airlineService.CreateNewAirline(name);

            Assert.Same(airline, this._airlineService.GetAirlineByName(name));

            this.Context.Airlines.Remove(airline);
        }

    }
}