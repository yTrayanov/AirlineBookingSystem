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
            Flight flight = this._flightService.GetFlightByIdAndAirline(flightId, airlineName);

            FlightSection newSection = new FlightSection(rows, cols, seatClass);

            this.ShouldContainKey(flight.Sections.Keys, seatClass.ToString(), false, "Section already exists");

            flight.Sections.Add(seatClass.ToString(), newSection);


            return newSection;
        }


        public Seat BookSeat(string airlineName, string flightId, SeatClass seatClass, int row, char colSymbol)
        {
            Flight flight = this._flightService.GetFlightByIdAndAirline(flightId, airlineName);

            FlightSection section = this._flightService.GetFlightSection(seatClass, flight);

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
