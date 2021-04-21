using AirlineBookingSystem.Models;
using AirlineBookingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineBookingSystem
{
    public class SystemManager
    {
        private AirlineService airlineService = new AirlineService();
        private AirportService airportService = new AirportService();
        private FlightService flightService = new FlightService();
        private SectionService sectionService = new SectionService();



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
                this.airlineService.CreateNewAirline(name);
                Console.WriteLine("Successfully created airline " + name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateFlight(string airlineName , string originAirportName ,
            string destinationAirportName, string year , string month , string day , string flightId)
        {
            try
            {
                flightService.CreateFlight(airlineName, originAirportName, destinationAirportName,
                    year, month, day, flightId);
                Console.WriteLine("Flight successfully created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateSection(string airlineName ,string flightId , string rows , string cols ,SeatClass seatClass)
        {
            try
            {
                int parsedRows;
                int parsedColumns;

                if(!int.TryParse(rows , out parsedRows) || !int.TryParse(cols , out parsedColumns))
                {
                    throw new ArgumentException("Invalid rows or columns");
                }

                this.sectionService.CreateSection(airlineName, flightId, parsedRows, parsedColumns, seatClass);
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
                    Console.WriteLine($"FlightNumber:{flight.Id} Departure Date:{flight.DepartureDate}");
                }
            }
        }

        public void BookSeat(string airlineName ,string flightId ,SeatClass seatClass ,string row , string col)
        {
            try
            {
                int parsedRow;
                char parsedCol;

                if(!int.TryParse(row, out parsedRow) || !char.TryParse(col ,out parsedCol))
                {
                    throw new ArgumentException("Invalid row or col");
                }

                this.sectionService.BookSeat(airlineName, flightId , seatClass, parsedRow, parsedCol);
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
                    string hasAvailableSeats = flight.hasAvalableSeats ? "Yes" : "No";

                    Console.WriteLine($"---FlightNumber: {flight.Id} OriginAirport: {flight.OriginAirport.Name} DestinationAirport: {flight.DestinationAirport.Name} Departure Date: {flight.DepartureDate} HasAvailableSeats:{hasAvailableSeats}");
                }
            }

        }

        public void AddNewSeats(string airlineName , string flightId , string rows , string cols , SeatClass seatClass)
        {
            try
            {
                int parsedRows;
                int parsedCols;

                if(!int.TryParse(rows, out parsedRows) || !int.TryParse(cols , out parsedCols))
                {
                    throw new ArgumentException("Extra rows and extra cols should be a number");
                }

                this.sectionService.AddSeatsToSection(airlineName, flightId, parsedRows, parsedCols, seatClass);

                Console.WriteLine($"Successfully added {rows} rows and {cols} coloumns to flight {flightId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
