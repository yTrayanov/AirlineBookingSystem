namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FlightService : Service
    {
        private AirlineService _airlineService;
        private AirportService _airportService;

        public FlightService(BaseContext context) : base(context)
        {
            this._airlineService = new AirlineService(context);
            this._airportService = new AirportService(context);
        }

        public Flight CreateFlight(string airlineName, string originAirportName,
            string destinationAirportName, string year, string month, string day, string flightId)
        {
            Airline airline = this._airlineService.GetAirlineByName(airlineName);

            Airport originAirport = this._airportService.GetAirportByName(originAirportName);

            Airport destinationAirport = this._airportService.GetAirportByName(destinationAirportName);

            DateTime flightDate = CheckIfDateIsValidAndReturnDate(year, month, day);

            if (CheckIfFlightIdAlreadyExist(flightId))
            {
                throw new ArgumentException("Flight number already exists!");
            }

            var flight = new Flight(airline, originAirport, destinationAirport, flightDate, flightId);


            airline.Flights.Add(flight);
            this.Context.Flights.Add(flight);

            return flight;

        }

        public Flight GetFlightByIdAndAirline(string flightId, string airlineName)
        {
            var flight = this.Context.Flights
                .FirstOrDefault(flight => flight.Id == flightId &&
                                flight.Airline.Name == airlineName);

            if (flight == null)
            {
                throw new ArgumentException($"Flight with number {flightId} and airline {airlineName} doesn't exist");
            }

            return flight;
        }


        public List<Flight> GetAvailableFlights(string originAirportName, string destinationAirportName)
        {
            return this.Context.Flights
                        .Where(f => f.hasAvalableSeats &&
                        f.DestinationAirport.Name == destinationAirportName &&
                        f.OriginAirport.Name == originAirportName)
                        .ToList();
        }


        public FlightSection GetFlightSection(SeatClass seatClass, Flight flight)
        {
            return flight.Sections.FirstOrDefault(section => section.SeatClass == seatClass);
        }

        private bool CheckIfFlightIdAlreadyExist(string flightId)
        {
            bool flightExists = this.Context.Flights.Any(flight => flight.Id == flightId);

            return flightExists;

        }
        private DateTime CheckIfDateIsValidAndReturnDate(string yearString, string monthString, string dayString)
        {
            int year;
            int month;
            int day;

            if (!int.TryParse(yearString, out year) ||
                !int.TryParse(monthString, out month) ||
                !int.TryParse(dayString, out day))
            {
                throw new ArgumentException("Date is invalid");
            }

            var flightDate = new DateTime(year, month, day);

            if (flightDate < DateTime.Now)
            {
                throw new ArgumentException("Can't create flights with past date");
            }

            return flightDate;
        }
    }
}
