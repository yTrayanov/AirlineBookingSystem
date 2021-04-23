using AirlineBookingSystem.Data;
using AirlineBookingSystem.Tests.Fixtures;
using Xunit;

namespace AirlineBookingSystem.Tests
{
    [Collection("TestCollection")]
    public abstract class BaseTest
    {

        public BaseTest(DatabaseFixture fixture)
        {
            this.Fixture = fixture;
        }

        public DatabaseFixture Fixture { get; set; }

        public BaseContext Context => this.Fixture.Context;
    }
}
