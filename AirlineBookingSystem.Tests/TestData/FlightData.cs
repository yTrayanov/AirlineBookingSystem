using AirlineBookingSystem.Tests.TestConstants;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Tests.TestData
{
    public static class FlightData
    {
        public static IEnumerable<object[]> ValidFlightData()
        {
            yield return new string[] { ConstantData.AirlineName, ConstantData.OriginAirport, ConstantData.DestionationAirport, "2050", "9", "6", "12345" }; 

            yield return new string[] { ConstantData.AirlineName, ConstantData.OriginAirport, ConstantData.DestionationAirport, "2050", "9", "6", "123" };
        }

        public static IEnumerable<object[]> InvalidFlightData()
        {
            yield return new string[] { ConstantData.AirlineName, ConstantData.OriginAirport, ConstantData.DestionationAirport, "2050", "9", "6", "" };

            yield return new string[] { "Invalid", ConstantData.OriginAirport, ConstantData.DestionationAirport, "2050", "9", "6", "123" };

            yield return new string[] { "Invalid", ConstantData.OriginAirport, ConstantData.DestionationAirport, "2050", "9", "6", "123" };

            yield return new string[] { ConstantData.AirlineName, ConstantData.OriginAirport, ConstantData.DestionationAirport, "100", "9", "6", "123" };

            yield return new string[] { ConstantData.AirlineName, ConstantData.OriginAirport, ConstantData.OriginAirport, "2050", "9", "6", "123" };

            yield return new string[] { ConstantData.AirlineName, ConstantData.OriginAirport, ConstantData.OriginAirport, "2050", "9", "6", ConstantData.FlightId };
        }
    }
}
