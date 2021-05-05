namespace AirlineBookingSystem.Tests.TestData
{
    using AirlineBookingSystem.Common;
    using System.Collections.Generic;
    public static class AirlineData
    {

        public static IEnumerable<object[]> ValidAirlineData()
        {
            yield return new string[] { "DONKER" };
            yield return new string[] { "DELTA" };
            yield return new string[] { "A" };
            yield return new string[] { "AHAHA" };
        }

        public static IEnumerable<object[]> InvalidAirlineNames()
        {
            yield return new string[] { "Invalid Name" };
            yield return new string[] { "" };
            yield return new string[] { null };
            yield return new string[] { "   " };
            yield return new string[] { "123" };
            yield return new string[] { "AAA AA" };
        }
    }
}
