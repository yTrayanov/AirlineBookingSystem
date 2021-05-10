using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirlineBookingSystem.Services
{
    public class AirportService : Service
    {
        public AirportService(BaseContext context) : base(context)
        {
        }

        public Airport CreateAirport(string name)
        {
            var newAirport = new Airport(name);

            this.ShouldContainKey(this.Context.Airports.Keys, name, false, $"Airport {name} already exists");

            this.Context.Airports.Add(name,newAirport);

            return newAirport;
        }

        public Airport GetAirportByName(string name)
        {
            this.ShouldContainKey(this.Context.Airports.Keys, name, true, $"Airport {name} doesn't exist!");

            return this.Context.Airports[name];
        }

        public List<Airport> GetAllAirports()
        {
            return this.Context.Airports.Values.ToList();
        }
    }
}
