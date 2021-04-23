namespace AirlineBookingSystem.Tests.Fixtures
{
    using Xunit;

    [CollectionDefinition("TestCollection")]
    public class CollectionFixture:ICollectionFixture<DatabaseFixture>
    {
    }
}
