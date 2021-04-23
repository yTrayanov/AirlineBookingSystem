﻿using AirlineBookingSystem.Models;
using AirlineBookingSystem.Models.Common;
using AirlineBookingSystem.Tests.TestConstants;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Tests.TestData
{
    public static class SectionData
    {

        public static IEnumerable<object[]> ValidSectionData()
        {
            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, 1, 1, SeatClass.bussiness};
        }

        public static IEnumerable<object[]> InvalidSectionData()
        {
            yield return new object[] { "invalid", ConstantData.FlightId, 1, 1, SeatClass.bussiness };

            yield return new object[] { ConstantData.AirlineName, "invalid", 3, 4, SeatClass.economy };

            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, ModelConstants.MaxSectionRows +1, ModelConstants.MaxSectionColumns - 1, SeatClass.economy };

            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId,ModelConstants.MaxSectionRows - 1 , ModelConstants.MaxSectionColumns + 1, SeatClass.first };

            //this should already exist
            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, 3, 10, SeatClass.first };
            
        }

        public static IEnumerable<object[]> ValidSeatData()
        {
            yield return new object[] {ConstantData.AirlineName, ConstantData.FlightId, SeatClass.first, 1, 'A' };
            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, SeatClass.first, 1, 'B' };
        }

        public static IEnumerable<object[]> InvalidSeatData()
        {
            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, SeatClass.first, ConstantData.FlightSectionRows + 1, 'J' };
            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, SeatClass.first, 1, Convert.ToChar(ConstantData.FlightSectionColumns + 1)};
        }

        public static IEnumerable<object[]> AddictionalSeatsValidData()
        {
            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, 1, 1, SeatClass.first }; 
            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, 2, 2, SeatClass.first };
        }

        public static IEnumerable<object[]> AddictionalSeatsInvalidData()
        {
            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, 1, 1, SeatClass.economy };

            yield return new object[] { "Invalid", ConstantData.FlightId, 1, 1, SeatClass.first };

            yield return new object[] { ConstantData.AirlineName, "Invalid", 1, 1, SeatClass.first };

            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, ModelConstants.MaxSectionRows, 1, SeatClass.first };

            yield return new object[] { ConstantData.AirlineName, ConstantData.FlightId, 1, ModelConstants.MaxSectionColumns, SeatClass.first };

        }
    }
}