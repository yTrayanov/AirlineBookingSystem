using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineBookingSystem.Services
{
    public class SectionService : Service
    {
        private FlightService flightService = new FlightService();
        public void CreateSection(string airlineName, string flightNumber, int rows, int cols, SeatClass seatClass)
        {
            Flight flight = flightService.GetFlightByIdAndAirline(flightNumber, airlineName);

            FlightSection section = new FlightSection(rows, cols, seatClass);

            if (flight.Sections.Contains(section))
            {
                throw new ArgumentException("Section already exists");
            }


            flight.Sections.Add(section);

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
    }
}
