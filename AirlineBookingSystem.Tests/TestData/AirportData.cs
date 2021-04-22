using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Tests.TestData
{
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
        }
    }
}
