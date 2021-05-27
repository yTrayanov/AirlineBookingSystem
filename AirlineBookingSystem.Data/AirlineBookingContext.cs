namespace AirlineBookingSystem.Data
{
    public class AirlineBookingContext : BaseContext
    {
        private static AirlineBookingContext _context = new AirlineBookingContext();

        private AirlineBookingContext()
        {
        }

        public static BaseContext GetContext()
        {
            return _context;
        }
    }
}
