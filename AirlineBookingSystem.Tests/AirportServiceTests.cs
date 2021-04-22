using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Services;
using AirlineBookingSystem.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AirlineBookingSystem.Tests
{
    public class AirportServiceTests:BaseTest
    {
        AirportService airportService = new AirportService(AirlineBookingTestContext.GetContext());

        [Theory]
        [MemberData(nameof(AirportData.ValidAirportData) , MemberType =typeof(AirportData))]
        public void CreateAirportWithValidData(string name)
        {
            Airport airport = this.airportService.CreateAirport(name);

            Assert.Contains(airport, this.Context.Airports);

            this.Context.Airports.Remove(airport);
        }

        [Theory]
        [MemberData(nameof(AirportData.InvalidAirportData) , MemberType =typeof(AirportData))]
        public void CreatAirportWithInvalidData(string name)
        {
            Assert.Throws<ArgumentException>(
                () => this.airportService.CreateAirport(name));
        }
    }
}
