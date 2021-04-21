using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineBookingSystem.Services
{
    public class FlightService:Service
    {
        private AirlineService _airlineService = new AirlineService();
        private AirportService _airportService = new AirportService();
        public void CreateFlight(string airlineName, string originAirportName,
            string destinationAirportName, string year, string month, string day, string flightId)
        {
            Airline airline = this._airlineService.GetAirlineByName(airlineName);
            Airport originAirport = this._airportService.GetAirportByName(originAirportName);
            Airport destinationAirport = this._airportService.GetAirportByName(destinationAirportName);



            DateTime flightDate = CheckIfDateIsValidAndReturnDate(year,month,day);

            if (CheckIfFlightIdAlreadyExist(flightId))
            {
                throw new ArgumentException("Flight number already exists!");
            }

            var flight = new Flight(airline, originAirport, destinationAirport, flightDate, flightId);
            
            
            airline.Flights.Add(flight);
            this.Context.Flights.Add(flight);

        }

        public Flight GetFlightByIdAndAirline(string id , string airline)
        {
            var flight = this.Context.Flights.FirstOrDefault(flight => flight.Id == id && flight.Airline.Name == airline);

            if(flight == null)
            {
                throw new ArgumentException($"Flight with number {id} and airline {airline} doesn't exist");
            }

            return flight;
        }


        public List<Flight> GetAvailableFlights(string originAirportName , string destinationAirportName)
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

        private DateTime CheckIfDateIsValidAndReturnDate( string yearString, string monthString, string dayString)
        {
            int year;
            int month;
            int day;

            if (!int.TryParse(yearString , out year) ||
                !int.TryParse(monthString , out month) || 
                !int.TryParse(dayString , out day))
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

        

        private bool CheckIfFlightIdAlreadyExist(string flightId)
        {
            bool flightExists = this.Context.Flights.Any(flight => flight.Id == flightId);

            return flightExists;

        }
    }
}
