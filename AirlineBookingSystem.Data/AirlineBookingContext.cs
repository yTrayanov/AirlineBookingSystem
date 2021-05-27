namespace AirlineBookingSystem.Data
{
    public class AirlineBookingContext : BaseContext
    {
        private static AirlineBookingContext _context = new AirlineBookingContext();

        private AirlineBookingContext()
        {
        }

        public static AirlineBookingContext GetContext()
        {
            return _context;
        }
    }
}
