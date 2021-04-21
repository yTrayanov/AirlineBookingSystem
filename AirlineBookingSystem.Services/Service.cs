using AirlineBookingSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Services
{
    public class Service
    {
        public Service()
        {
            this.Context = AirlineBookingContext.GetContext();
        }

        public AirlineBookingContext Context { get; set; }
    }
}
