using AirlineBookingSystem.Models;
using System;

namespace AirlineBookingSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var systemManager = new SystemManager();

            systemManager.CreateAirport("");
            systemManager.CreateAirport(null);
            systemManager.CreateAirport("DDDD");
            systemManager.CreateAirport("NYC");
            systemManager.CreateAirport("NYC");
            systemManager.CreateAirport("AAA");
            systemManager.CreateAirport("CCC");
            systemManager.CreateAirport("BBB");

            Console.WriteLine();

            systemManager.CreateAirline("");
            systemManager.CreateAirline(null);
            systemManager.CreateAirline("1234567");
            systemManager.CreateAirline("DD");
            systemManager.CreateAirline("DELTA");
            systemManager.CreateAirline("DELTA");
            systemManager.CreateAirline("HAHAHA");
            Console.WriteLine();

            systemManager.CreateFlight("", "", "", 1, 1, 1, "");
            systemManager.CreateFlight("DDD", "NYC", "AAA", 2022, 9, 1, "123");
            systemManager.CreateFlight("DD", "NYC", "NYC", 2022, 9, 1, "123");
            systemManager.CreateFlight("DD", "NYC", "AAA", 2000, 9, 1, "123");
            systemManager.CreateFlight("DD", null, "AAA", 2000, 9, 1, "123");
            systemManager.CreateFlight("DD", "NYC", "AAA", 10 , 9, 1, "123");
            systemManager.CreateFlight("DD", "NYC", "AAA", 2022, 9, 1, "123");
            systemManager.CreateFlight("DELTA", "NYC", "AAA", 2022, 9, 6, "1234");
            systemManager.CreateFlight("DELTA", "AAA", "BBB", 2025, 2, 16, "2222");
            systemManager.CreateFlight("HAHAHA", "BBB", "CCC", 2050, 12, 31, "1111");
            Console.WriteLine();

            systemManager.CreateSection("", "", 0, 0, SeatClass.bussiness);
            systemManager.CreateSection("DD", "123", 101, 9, SeatClass.bussiness);
            systemManager.CreateSection("DD", "123", 10, 11, SeatClass.bussiness);
            systemManager.CreateSection("DD", "123", 100, 10, SeatClass.first);
            systemManager.CreateSection("DELTA", "1234", 5, 5, SeatClass.economy);
            systemManager.CreateSection("DELTA", "2222", 1, 1, SeatClass.bussiness);
            Console.WriteLine();

            systemManager.FindAvailableFlights("NYC", "AAA");
            Console.WriteLine();

            systemManager.BookSeat("DD", "123", SeatClass.first, 10, 'A');
            systemManager.BookSeat("DELTA", "2222", SeatClass.bussiness, 1, 'A');
            Console.WriteLine();

            systemManager.DisplaySystemDetails();

            Console.WriteLine();

        }
    }
}
