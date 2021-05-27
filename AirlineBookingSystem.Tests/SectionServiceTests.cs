namespace AirlineBookingSystem.Tests
{
    using AirlineBookingSystem.Models;
    using AirlineBookingSystem.Services;
    using AirlineBookingSystem.Tests.Constants;
    using AirlineBookingSystem.Tests.Fixtures;
    using AirlineBookingSystem.Tests.TestData;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Xunit;

    public class SectionServiceTests : BaseTest
    {

        private SectionService _sectionService;

        public SectionServiceTests(DatabaseFixture fixture) : base(fixture)
        {
            this._sectionService = new SectionService(fixture.Context);
        }

        [Theory]
        [MemberData(nameof(SectionData.ValidSectionData), MemberType = typeof(SectionData))]
        public void CreateSectionWithValidData(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            FlightSection section = this._sectionService.CreateSection(airlineName, flightId, rows, cols, seatClass);

            var flight = this.Context.Flights[flightId];

            Assert.Contains(section, flight.Sections.Values);
        }


        [Theory]
        [MemberData(nameof(SectionData.InvalidSectionModelData), MemberType = typeof(SectionData))]
        public void CreateSectionWithInvalidModelData(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            Assert.Throws<ValidationException>(
                () => this._sectionService.CreateSection(airlineName, flightId, rows, cols, seatClass));
        }

        [Theory]
        [MemberData(nameof(SectionData.InvalidSectionArgumentData), MemberType = typeof(SectionData))]
        public void CreateSectionWithInvalidArgumentData(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            Assert.Throws<ArgumentException>(
                () => this._sectionService.CreateSection(airlineName, flightId, rows, cols, seatClass));
        }

        [Theory]
        [MemberData(nameof(SectionData.ValidSeatData), MemberType = typeof(SectionData))]
        public void BookValidSeat(string airlineName, string flightId, SeatClass seatClass, int row, char colSymbol)
        {
            Seat seat = this._sectionService.BookSeat(airlineName, flightId, seatClass, row, colSymbol);

            Assert.True(seat.IsBooked);

        }


        [Theory]
        [MemberData(nameof(SectionData.InvalidSeatData), MemberType = typeof(SectionData))]
        public void BookInvalidSeat(string airlineName, string flightId, SeatClass seatClass, int row, char colSymbol)
        {
            Assert.Throws<ArgumentException>(
                () => this._sectionService.BookSeat(airlineName, flightId, seatClass, row, colSymbol));
        }

        [Fact]
        public void FlightHasNoAvailableSeatsAfterFullyBooked()
        {
            Flight flight = this.Context.Flights[TestConstants.FullFlight];

            FlightSection section = flight.Sections.Values.FirstOrDefault(s => s.SeatClass == SeatClass.first);

            Assert.True(flight.IsAvailable);

            for (int row = 0; row < section.Seats.GetLength(0); row++)
            {
                for (int col = 0; col < section.Seats.GetLength(1); col++)
                {
                    if (!section.Seats[row, col].IsBooked)
                        section.BookSeat(row, col);
                }
            }

            Assert.False(flight.IsAvailable);
        }
    }
}
