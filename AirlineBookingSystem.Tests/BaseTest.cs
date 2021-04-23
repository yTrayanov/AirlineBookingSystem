namespace AirlineBookingSystem.Tests
{
    using AirlineBookingSystem.Data;
    using AirlineBookingSystem.Tests.Fixtures;
    using Xunit;

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
