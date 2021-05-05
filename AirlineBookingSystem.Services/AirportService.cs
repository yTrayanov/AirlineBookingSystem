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
            var newAirport = new Airport(name);
            this.ValidateModel(newAirport);

            if (this.Context.Airports.ContainsKey(name))
            {
                throw new ArgumentException($"Airport {name} already exists");
            }

            this.Context.Airports.Add(name,newAirport);

            return newAirport;
        }

        public Airport GetAirportByName(string name)
        {

            if (!this.Context.Airports.ContainsKey(name))
            {
                throw new ArgumentException($"Airport {name} doesn't exist!");
            }

            return this.Context.Airports[name];
        }

        public List<Airport> GetAllAirports()
        {
            return this.Context.Airports.Values.ToList();
        }
    }
}
