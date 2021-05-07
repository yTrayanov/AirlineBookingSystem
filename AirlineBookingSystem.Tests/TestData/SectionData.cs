namespace AirlineBookingSystem.Tests.TestData
{
    using AirlineBookingSystem.Models;
    using AirlineBookingSystem.Models.Constants;
    using AirlineBookingSystem.Tests.Constants;
    using System;
    using System.Collections.Generic;

    public static class SectionData
    {

        public static IEnumerable<object[]> ValidSectionData()
        {
            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, 1, 1, SeatClass.bussiness};
        }

        public static IEnumerable<object[]> InvalidSectionModelData()
        {
            

            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, ModelConstants.MaxSectionRows +1, ModelConstants.MaxSectionColumns - 1, SeatClass.economy };

            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId,ModelConstants.MaxSectionRows - 1 , ModelConstants.MaxSectionColumns + 1, SeatClass.first };

            
        }

        public static IEnumerable<object[]> InvalidSectionArgumentData()
        {
            //this should already exist
            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, 3, 10, SeatClass.first };

            yield return new object[] { "invalid", TestConstants.FlightId, 1, 1, SeatClass.economy };

            yield return new object[] { TestConstants.AirlineName, "invalid", 3, 4, SeatClass.economy };
        }


        public static IEnumerable<object[]> ValidSeatData()
        {
            yield return new object[] {TestConstants.AirlineName, TestConstants.FlightId, SeatClass.first, 1, 'A' };
            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, SeatClass.first, 1, 'B' };
        }

        public static IEnumerable<object[]> InvalidSeatData()
        {
            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, SeatClass.first, TestConstants.FlightSectionRows + 20, 'J' };

            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, SeatClass.first, 1, Convert.ToChar(TestConstants.FlightSectionColumns + 1)};
        }

        public static IEnumerable<object[]> AddictionalSeatsValidData()
        {
            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, 1, 1, SeatClass.first }; 
            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, 2, 2, SeatClass.first };
        }

        public static IEnumerable<object[]> AddictionalSeatsInvalidArgumentData()
        {
            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, 1, 1, SeatClass.economy };

            yield return new object[] { "Invalid", TestConstants.FlightId, 1, 1, SeatClass.first };

            yield return new object[] { TestConstants.AirlineName, "Invalid", 1, 1, SeatClass.first };



        }

        public static IEnumerable<object[]> AddictionalSeatsInvalidModelData()
        {

            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, ModelConstants.MaxSectionRows, 1, SeatClass.first };


            yield return new object[] { TestConstants.AirlineName, TestConstants.FlightId, 1, ModelConstants.MaxSectionColumns, SeatClass.first };
        }
    }
}
