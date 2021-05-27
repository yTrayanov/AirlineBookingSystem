namespace AirlineBookingSystem.Tests.TestData
{
    using AirlineBookingSystem.Tests.Constants;
    using System;
    using System.Collections.Generic;

    public static class FlightData
    {
        private static int FutureYear = DateTime.Now.Year + 100;

        public static IEnumerable<object[]> ValidFlightData()
        {
            yield return new object[] { TestConstants.AirlineName, TestConstants.OriginAirport, TestConstants.DestionationAirport, FutureYear, 9, 6, "12345" }; 

            yield return new object[] { TestConstants.AirlineName, TestConstants.OriginAirport, TestConstants.DestionationAirport, FutureYear, 9, 6, "12355" };
        }

        public static IEnumerable<object[]> InvalidFlightData()
        {
            yield return new object[] { TestConstants.AirlineName, TestConstants.OriginAirport, TestConstants.DestionationAirport,FutureYear, 9, 6, "" };

            yield return new object[] { TestConstants.AirlineName, TestConstants.OriginAirport, TestConstants.DestionationAirport, 100, 9, 6, "123" };

            yield return new object[] { TestConstants.AirlineName, TestConstants.OriginAirport, TestConstants.OriginAirport, FutureYear, 9, 6, "12390" };

            yield return new object[] { TestConstants.AirlineName, TestConstants.OriginAirport, TestConstants.OriginAirport, FutureYear, 9, 6, TestConstants.FlightId };
        }
    }
}
