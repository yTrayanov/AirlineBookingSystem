namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Models;
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

            this.ShouldContainKey(this.Context.Airlines.Keys, name, false, $"Airline {name} already exists");

            this.Context.Airlines.Add(name , newAirline);

            return newAirline;
        }

        public List<Airline> GetAllAirlines()
        {
            return this.Context.Airlines.Values.ToList();
        }
    }
}
