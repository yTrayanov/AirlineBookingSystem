namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    public class AirlineService: Service
    {
        public AirlineService(BaseContext context) : base(context)
        {
        }

        public Airline CreateAirline(string name)
        {
            if(this.Context.Airlines.Any(a => a.Name == name))
            {
                throw new ArgumentException("Airline already exists!");
            }

            Airline newAirline = new Airline(name);
            Validator.ValidateObject(newAirline, new ValidationContext(newAirline), true);

            this.Context.Airlines.Add(newAirline);

            return newAirline;
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
