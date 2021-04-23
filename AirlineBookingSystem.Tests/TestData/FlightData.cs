using AirlineBookingSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Tests.TestData
{
    public static class FlightData
    {
        public static IEnumerable<object[]> ValidFlightData()
        {
            yield return new string[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, "2050", "9", "6", "12345" }; 

            yield return new string[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, "2050", "9", "6", "123" };
        }

        public static IEnumerable<object[]> InvalidFlightData()
        {
            yield return new string[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, "2050", "9", "6", "" };

            yield return new string[] { "Invalid", ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, "2050", "9", "6", "123" };

            yield return new string[] { "Invalid", ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, "2050", "9", "6", "123" };

            yield return new string[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, "100", "9", "6", "123" };

            yield return new string[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.OriginAirport, "2050", "9", "6", "123" };

            yield return new string[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.OriginAirport, "2050", "9", "6", ConstantTestData.FlightId };
        }
    }
}
