using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Services;
using AirlineBookingSystem.Tests.TestConstants;
using AirlineBookingSystem.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AirlineBookingSystem.Tests
{
    public class AirportServiceTests:BaseTest
    {
        private AirportService _airportService = new AirportService(AirlineBookingTestContext.GetContext());

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
            Assert.Throws<ArgumentException>(
                () => this._airportService.CreateAirport(name));
        }

        [Theory]
        [InlineData(ConstantData.OriginAirport)]
        [InlineData(ConstantData.DestionationAirport)]
        public void GetAiportByNameWithValidAirports(string airportName)
        {
            Airport airport = this._airportService.GetAirportByName(airportName);

            Assert.Equal(airportName, airport.Name);
        }
    }
}
