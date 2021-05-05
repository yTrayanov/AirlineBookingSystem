namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class SectionService : Service
    {
        private FlightService _flightService;

        public SectionService(BaseContext context) : base(context)
        {
            this._flightService = new FlightService(context);
        }

        public FlightSection CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            Flight flight = _flightService.GetFlightByIdAndAirline(flightId, airlineName);

            FlightSection newSection = new FlightSection(rows, cols, seatClass);
            this.ValidateModel(newSection);

            AddNewSection(seatClass, flight, newSection);

            return newSection;

        }


        public Seat BookSeat(string airlineName , string flightId , SeatClass seatClass ,int row , char colSymbol)
        {
            Flight flight = this._flightService.GetFlightByIdAndAirline(flightId, airlineName);

            FlightSection section = this._flightService.GetFlightSection(seatClass, flight);

            if (section == null)
            {
                throw new ArgumentException($"This flight does't have {seatClass} section");
            }

            try
            {
                int col = (int)(colSymbol - 'A');
                Seat seat = section.Seats[row-1, col];

                if (seat.IsBooked)
                {
                    throw new ArgumentException($"Seat {seat.Id} is already booked");
                }
                else
                {
                    seat.IsBooked = true;
                }

                return seat;
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

        public FlightSection AddSeatsToSection(string airlineName , string flightId , int extraRows , int extraCols , SeatClass seatClass)
        {
            var flight = this._flightService.GetFlightByIdAndAirline(flightId, airlineName);

            var oldSection = flight.Sections.FirstOrDefault(s => s.SeatClass == seatClass);

            if(oldSection == null)
            {
                throw new ArgumentException($"Flight doesn't have {seatClass} section");
            }

            if(extraRows == 0 && extraCols == 0)
            {
                throw new ArgumentException("Addictional rows and cols should be greater than 0");
            }

            var newRows = oldSection.Seats.GetLength(0) + extraRows;
            var newCols = oldSection.Seats.GetLength(1) + extraCols;



            var newSection = new FlightSection(newRows, newCols, oldSection.SeatClass);
            this.ValidateModel(newSection);

            flight.Sections.Remove(oldSection);

            AddNewSection(newSection.SeatClass, flight, newSection);


            for (int row = 0; row < oldSection.Seats.GetLength(0); row++)
            {
                for (int col = 0; col < oldSection.Seats.GetLength(1); col++)
                {
                    newSection.Seats[row, col] = oldSection.Seats[row, col];
                }
            }


            return newSection;
        }

        private static void AddNewSection(SeatClass seatClass, Flight flight, FlightSection section)
        {
            if (flight.Sections.Any(s => s.SeatClass == seatClass))
            {
                throw new ArgumentException("Section already exists");
            }

            flight.Sections.Add(section);
        }

    }
}
