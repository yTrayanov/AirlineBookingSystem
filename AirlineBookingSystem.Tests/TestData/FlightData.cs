namespace AirlineBookingSystem.Tests.TestData
{
    using AirlineBookingSystem.Common;
    using System.Collections.Generic;

    public static class FlightData
    {
        public static IEnumerable<object[]> ValidFlightData()
        {
            yield return new object[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, 2050, 9, 6, "12345" }; 

            yield return new object[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, 2050, 9, 6, "12355" };
        }

        public static IEnumerable<object[]> InvalidFlightData()
        {
            yield return new object[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, 2050, 9, 6, "" };


            yield return new object[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.DestionationAirport, 100, 9, 6, "123" };

            yield return new object[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.OriginAirport, 2050, 9, 6, "123" };

            yield return new object[] { ConstantTestData.AirlineName, ConstantTestData.OriginAirport, ConstantTestData.OriginAirport, 2050, 9, 6, ConstantTestData.FlightId };
        }
    }
}
