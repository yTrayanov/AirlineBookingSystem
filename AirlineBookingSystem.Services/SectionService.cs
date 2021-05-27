namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
    using System;

    public class SectionService : Service
    {
        private FlightService _flightService;

        public SectionService(BaseContext context) : base(context)
        {
            this._flightService = new FlightService(context);
        }

        public FlightSection CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {

            this.ShouldContainKey(this.Context.Flights.Keys, flightId, true, $"Flight with number {flightId} doesn't exist");
            FlightSection newSection = new FlightSection(rows, cols, seatClass);

            if(this.Context.Flights[flightId].Airline.Name != airlineName)
            {
                throw new ArgumentException($"Flight with number {flightId} and airline {airlineName} doesn't exist");
            }

            this.ShouldContainKey(this.Context.Flights[flightId].Sections.Keys, seatClass.ToString(), false, "Section already exists");

            this.Context.Flights[flightId].Sections.Add(seatClass.ToString(), newSection);


            return newSection;
        }


        public Seat BookSeat(string airlineName, string flightId, SeatClass seatClass, int row, char colSymbol)
        {
            this.ShouldContainKey(this.Context.Flights.Keys, flightId, true, $"Flight with number {flightId} doesn't exist");

            Flight flight = this.Context.Flights[flightId];

            this.ShouldContainKey(flight.Sections.Keys, seatClass.ToString(), true, $"Flight section {seatClass} doesn't exist");
            FlightSection section = flight.Sections[seatClass.ToString()];

            try
            {
                int col = (int)(colSymbol - 'A');
                
                section.BookSeat(row - 1, col);

                return section.Seats[row-1,col];
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("Seat doesn't exist");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
