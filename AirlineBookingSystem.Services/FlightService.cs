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
            string destinationAirportName, int year, int month, int day, string flightId)
        {
            Airline airline = this._airlineService.GetAirlineByName(airlineName);

            Airport originAirport = this._airportService.GetAirportByName(originAirportName);

            Airport destinationAirport = this._airportService.GetAirportByName(destinationAirportName);

            DateTime flightDate = new DateTime(year, month, day);

            var newFlight = new Flight(airline, originAirport, destinationAirport, flightDate, flightId);

            this.ShouldContainKey(this.Context.Flights.Keys, flightId, false, "Flight number already exists!");

            airline.Flights.Add(newFlight);
            this.Context.Flights.Add(flightId, newFlight);

            return newFlight;
        }

        public Flight GetFlightByIdAndAirline(string flightId, string airlineName)
        {
            if (this.Context.Flights.ContainsKey(flightId) && this.Context.Flights[flightId].Airline.Name == airlineName)
            {
                return this.Context.Flights[flightId];
            }

            throw new ArgumentException($"Flight with number {flightId} and airline {airlineName} doesn't exist");
        }

        public List<Flight> GetAvailableFlights(string originAirportName, string destinationAirportName)
        {
            return this.Context.Flights.Values
                    .Where(flight => flight.IsAvailable &&
                            flight.OriginAirport.Name == originAirportName &&
                            flight.DestinationAirport.Name == destinationAirportName)
                    .ToList();
        }

        public FlightSection GetFlightSection(SeatClass seatClass, Flight flight)
        {
            this.ShouldContainKey(flight.Sections.Keys, seatClass.ToString(), true, $"This flight does't have {seatClass} section");

            return flight.Sections[seatClass.ToString()];
        }

    }
}
