using AirlineBookingSystem.Models;
using System;

namespace AirlineBookingSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var systemManager = new SystemManager();

            systemManager.CreateAirline("DELTA");
            systemManager.CreateAirport("ORG");
            systemManager.CreateAirport("DES");

            systemManager.CreateFlight("DELTA", "ORG", "DES", 100, 9, 6, "1111");

        }
    }
}
