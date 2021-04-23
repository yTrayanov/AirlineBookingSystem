using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AirlineBookingSystem.Tests.Fixtures
{
    [CollectionDefinition("TestCollection")]
    public class CollectionFixture:ICollectionFixture<DatabaseFixture>
    {
    }
}
