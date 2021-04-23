namespace AirlineBookingSystem.Tests.TestData
{
    using System.Collections.Generic;

    public static class AirportData
    {
        public static IEnumerable<object[]> ValidAirportData()
        {
            yield return new string[] { "NNN"};
            yield return new string[] { "NYC" };
            yield return new string[] { "LAA" };
        }

        public static IEnumerable<object[]> InvalidAirportData()
        {
            yield return new string[] { "Invalid Name" };
            yield return new string[] { "" };
            yield return new string[] { null };
            yield return new string[] { "   " };
            yield return new string[] { "123" };
        }
    }
}
