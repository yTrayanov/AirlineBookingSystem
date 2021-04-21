using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirlineBookingSystem.Services
{
    public class AirlineService: Service
    {
        public void CreateNewAirline(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Airline name is required!");
            }

            if(this.Context.Airlines.Any(a => a.Name == name))
            {
                throw new ArgumentException("Airline already exists!");
            }

            this.Context.Airlines.Add(new Airline(name));
        }

        public Airline GetAirlineByName(string name)
        {
            var airline = this.Context.Airlines
                .FirstOrDefault(airline => airline.Name == name);

            if (airline == null)
            {
                throw new ArgumentException($"Airline {name} doesn't exist!");
            }

            return airline;
        }

        public List<Airline> GetAllAirlines()
        {
            return this.Context.Airlines;
        }
    }
}
