using AirlineBookingSystem.Common;
using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Data
{
    public class AirlineBookingTestContext : BaseContext
    {
        private static AirlineBookingTestContext _context = new AirlineBookingTestContext();

        private AirlineBookingTestContext()
        {
        }

        public static AirlineBookingTestContext GetContext()
        {
            return _context;
        }

    }
}
