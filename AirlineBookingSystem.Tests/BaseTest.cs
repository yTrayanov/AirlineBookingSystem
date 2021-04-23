using AirlineBookingSystem.Data;
using AirlineBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AirlineBookingSystem.Tests
{
    public abstract class BaseTest:IClassFixture<DatabaseFixture>
    {


        public BaseTest(DatabaseFixture fixture)
        {
            this.Fixture = fixture;
        }

        public DatabaseFixture Fixture { get; set; }

        public BaseContext Context => this.Fixture.Context;
    }
}
