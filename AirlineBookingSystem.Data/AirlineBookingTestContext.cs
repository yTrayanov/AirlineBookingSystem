namespace AirlineBookingSystem.Data
{
    public class AirlineBookingTestContext : BaseContext
    {
        private static AirlineBookingTestContext _context = new AirlineBookingTestContext();

        private AirlineBookingTestContext()
        {
        }

        public static BaseContext GetContext()
        {
            return _context;
        }
    }
}
