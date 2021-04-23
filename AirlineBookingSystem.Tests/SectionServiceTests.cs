using AirlineBookingSystem.Common;
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
    public class SectionServiceTests : BaseTest
    {

        private SectionService _sectionService;

        public SectionServiceTests(DatabaseFixture fixture) : base(fixture)
        {
            this._sectionService = new SectionService(fixture.Context);
        }

        [Theory]
        [MemberData(nameof(SectionData.ValidSectionData) , MemberType =typeof(SectionData))]
        public void CreateSectionWithValidData(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            FlightSection section = this._sectionService.CreateSection(airlineName, flightId, rows, cols, seatClass);

            var flight = this.Context.Flights.FirstOrDefault(f => f.Id == flightId);

            Assert.Contains(section, flight.Sections);
        }


        [Theory]
        [MemberData(nameof(SectionData.InvalidSectionData), MemberType = typeof(SectionData))]
        public void CreateSectionWithInvalidData(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            Assert.Throws<ArgumentException>(
                () => this._sectionService.CreateSection(airlineName, flightId, rows, cols, seatClass));
        }

        [Theory]
        [MemberData(nameof(SectionData.ValidSeatData), MemberType = typeof(SectionData))]
        public void BookValidSeat(string airlineName, string flightId, SeatClass seatClass, int row, char colSymbol)
        {
            Seat seat = this._sectionService.BookSeat(airlineName, flightId , seatClass , row , colSymbol);

            Assert.True(seat.IsBooked);

        }


        [Theory]
        [MemberData(nameof(SectionData.InvalidSeatData), MemberType = typeof(SectionData))]
        public void BookInvalidSeat(string airlineName, string flightId, SeatClass seatClass, int row, char colSymbol)
        {
            Assert.Throws<ArgumentException>(
                () => this._sectionService.BookSeat(airlineName, flightId, seatClass, row, colSymbol));
        }

        [Theory]
        [MemberData(nameof(SectionData.AddictionalSeatsValidData), MemberType = typeof(SectionData))]
        public void AddSeatsToSectionWithValidData(string airlineName, string flightId, int extraRows, int extraCols, SeatClass seatClass)
        {
            FlightSection oldSection = this.Context
                .Flights.FirstOrDefault(f => f.Id == flightId && f.Airline.Name == airlineName)
                .Sections.FirstOrDefault(s => s.SeatClass == seatClass);

            FlightSection newSection = this._sectionService.AddSeatsToSection(airlineName, flightId, extraRows, extraCols, seatClass);

            Assert.Equal(oldSection.Rows + extraRows, newSection.Rows);
            Assert.Equal(oldSection.Columns + extraCols, newSection.Columns);
 

            //This seat is booked in the base class and should stay booked even after adding new seats;
            Assert.True(newSection.Seats[ConstantTestData.FlightSectionRows - 1, ConstantTestData.FlightSectionColumns - 1].IsBooked);
        }

        [Theory]
        [MemberData(nameof(SectionData.AddictionalSeatsInvalidData), MemberType = typeof(SectionData))]
        public void AddSeatsToSectionWithInvalidData(string airlineName, string flightId, int extraRows, int extraCols, SeatClass seatClass)
        {
            Assert.Throws<ArgumentException>(
                () => this._sectionService.AddSeatsToSection(airlineName, flightId, extraRows, extraCols, seatClass));
        }
    }
}
