namespace AirlineBookingSystem
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
    using AirlineBookingSystem.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SystemManager
    {
        private static BaseContext _context = AirlineBookingContext.GetContext();

        private AirlineService airlineService = new AirlineService(_context);
        private AirportService airportService = new AirportService(_context);
        private FlightService flightService = new FlightService(_context);
        private SectionService sectionService = new SectionService(_context);


        public void CreateAirport(string name)
        {
            try
            {
                this.airportService.CreateAirport(name);
                Console.WriteLine("Successfully created airport " + name);
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateAirline(string name)
        {
            try
            {
                this.airlineService.CreateAirline(name);
                Console.WriteLine("Successfully created airline " + name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateFlight(string airlineName , string originAirportName ,
            string destinationAirportName, int year , int month , int day , string flightId)
        {
            try
            {
                flightService.CreateFlight(airlineName, originAirportName, destinationAirportName,
                    year, month, day, flightId);
                Console.WriteLine("Flight successfully created");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid date");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateSection(string airlineName ,string flightId , int rows , int cols ,SeatClass seatClass)
        {
            try
            {
                this.sectionService.CreateSection(airlineName, flightId, rows, cols, seatClass);

                Console.WriteLine($"Successfully created {seatClass} section for flight {flightId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void FindAvailableFlights(string originAirportName ,string destinationAirportName)
        {
            List<Flight> flights = this.flightService.GetAvailableFlights(originAirportName, destinationAirportName);

            if (flights.Count == 0)
            {
                Console.WriteLine("There are no available flights");
            }
            else
            {
                foreach (var flight in flights)
                {
                    Console.WriteLine($"FlightNumber:{flight.Id} Departure Date:{flight.DepartureDate} Airline: {flight.Airline.Name}");
                }
            }
        }

        public void BookSeat(string airlineName ,string flightId ,SeatClass seatClass ,int row , char colSymbol)
        {
            try
            {
                this.sectionService.BookSeat(airlineName, flightId , seatClass, row, colSymbol);
                Console.WriteLine("Seat booked successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplaySystemDetails()
        {
            List<Airline> airlines = this.airlineService.GetAllAirlines();
            List<Airport> airports = this.airportService.GetAllAirports();

            Console.WriteLine("Airports:");
            foreach (var airport in airports.OrderBy(a => a.Name))
            {
                Console.WriteLine("-" + airport.Name);
            }

            Console.WriteLine("Airlines:");
            foreach (var airline in airlines.OrderBy(a => a.Name))
            {
                Console.WriteLine("-" + airline.Name);
                foreach (var flight in airline.Flights)
                {
                    string hasAvailableSeats = flight.IsAvailable ? "Yes" : "No";

                    Console.WriteLine($"---FlightNumber: {flight.Id} OriginAirport: {flight.OriginAirport.Name} DestinationAirport: {flight.DestinationAirport.Name} Departure Date: {flight.DepartureDate} HasAvailableSeats:{hasAvailableSeats}");
                }
            }

        }
    }
}
