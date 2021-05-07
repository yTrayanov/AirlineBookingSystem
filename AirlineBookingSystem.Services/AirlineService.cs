namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class AirlineService: Service
    {
        public AirlineService(BaseContext context) : base(context)
        {
        }

        public Airline CreateAirline(string name)
        {
            Airline newAirline = new Airline(name);
            this.ValidateModel(newAirline);

            if (this.Context.Airlines.ContainsKey(name))
            {
                throw new ArgumentException($"Airline {name} already exists");
            }

            this.Context.Airlines.Add(name , newAirline);

            return newAirline;
        }

        public Airline GetAirlineByName(string name)
        {
            if (!this.Context.Airlines.ContainsKey(name))
            {
                throw new ArgumentException($"Airline {name} doesn't exist!");
            }

            return this.Context.Airlines[name];
        }

        public List<Airline> GetAllAirlines()
        {
            return this.Context.Airlines.Values.ToList();
        }
    }
}
