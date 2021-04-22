using AirlineBookingSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Services
{
    public class Service
    {
        protected Service(BaseContext context)
        {
            this.Context = context;
        }

        public BaseContext Context { get; set; }
    }
}
