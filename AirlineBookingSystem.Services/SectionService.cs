using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineBookingSystem.Services
{
    public class SectionService : Service
    {
        private FlightService flightService;

        public SectionService(BaseContext context) : base(context)
        {
            this.flightService = new FlightService(context);
        }

        public FlightSection CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            Flight flight = flightService.GetFlightByIdAndAirline(flightId, airlineName);

            FlightSection section = new FlightSection(rows, cols, seatClass);

            if (flight.Sections.Contains(section))
            {
                throw new ArgumentException("Section already exists");
            }


            flight.Sections.Add(section);

            return section;

        }

        public void BookSeat(string airlineName , string flightId , SeatClass seatClass ,int row , char colSymbol)
        {
            Flight flight = this.flightService.GetFlightByIdAndAirline(flightId, airlineName);

            FlightSection section = this.flightService.GetFlightSection(seatClass, flight);

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

        public void AddSeatsToSection(string airlineName , string flightId , int extraRows , int extraCols , SeatClass seatClass)
        {
            var flight = this.flightService.GetFlightByIdAndAirline(flightId, airlineName);

            if(flight == null)
            {
                throw new ArgumentException("Flight not found!");
            }

            var oldSection = flight.Sections.FirstOrDefault(s => s.SeatClass == seatClass);

            if(oldSection == null)
            {
                throw new ArgumentException($"Flight doesn't have {seatClass} section");
            }

            if(extraRows == 0 && extraCols == 0)
            {
                throw new ArgumentException("Addictional rows and cols should be greater than 0");
            }

            flight.Sections.Remove(oldSection);
            var newRows = oldSection.Seats.GetLength(0) + extraRows;
            var newCols = oldSection.Seats.GetLength(1) + extraCols;


            var newSection = this.CreateSection(flight.Airline.Name, flight.Id, newRows, newCols, oldSection.SeatClass);

            for (int row = 0; row < oldSection.Seats.GetLength(0); row++)
            {
                for (int col = 0; col < oldSection.Seats.GetLength(1); col++)
                {
                    newSection.Seats[row, col] = oldSection.Seats[row, col];
                }
            }

        }
    }
}
