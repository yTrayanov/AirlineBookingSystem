using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AirlineBookingSystem.Services
{
    public class AirportService : Service
    {
        public AirportService(BaseContext context) : base(context)
        {
        }

        public Airport CreateAirport(string name)
        {

            if (this.Context.Airports.Any(a => a.Name == name))
            {
                throw new ArgumentException("Airport already exists!");
            }

            var newAirport = new Airport(name);
            Validator.ValidateObject(newAirport, new ValidationContext(newAirport), true);

            this.Context.Airports.Add(newAirport);

            return newAirport;
        }

        public Airport GetAirportByName(string name)
        {
            var airport = this.Context.Airports
                .FirstOrDefault(airline => airline.Name == name);

            if (airport == null)
            {
                throw new ArgumentException($"Airport {name} doesn't exist!");
            }

            return airport;
        }

        public List<Airport> GetAllAirports()
        {
            return this.Context.Airports;
        }
    }
}
