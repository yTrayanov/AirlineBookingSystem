namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FlightService : Service
    {

        public FlightService(BaseContext context) : base(context)
        {
        }

        public Flight CreateFlight(string airlineName, string originAirportName,
            string destinationAirportName, int year, int month, int day, string flightId)
        {
            DateTime flightDate = new DateTime(year, month, day);

            this.ShouldContainKey(this.Context.Flights.Keys, flightId, false, "Flight number already exists!");
            this.ShouldContainKey(this.Context.Airlines.Keys, airlineName, true, $"Airline {airlineName} doesn't exist");
            this.ShouldContainKey(this.Context.Airports.Keys, originAirportName, true, $"Airport {originAirportName} doesn't exist");
            this.ShouldContainKey(this.Context.Airports.Keys, destinationAirportName, true, $"Airport {destinationAirportName} doesn't exist");

            Flight newFlight = new Flight(this.Context.Airlines[airlineName] , this.Context.Airports[originAirportName] , this.Context.Airports[destinationAirportName], flightDate , flightId);

            this.Context.Flights.Add(flightId, newFlight);

            return newFlight;
        }

        public List<Flight> GetAvailableFlights(string originAirportName, string destinationAirportName)
        {
            return this.Context.Flights.Values
                    .Where(flight => flight.IsAvailable &&
                            flight.OriginAirport.Name == originAirportName &&
                            flight.DestinationAirport.Name == destinationAirportName)
                    .ToList();
        }
    }
}
