namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;

    public class Service
    {
        protected Service(BaseContext context)
        {
            this.Context = context;
        }

        public BaseContext Context { get; set; }
    }
}
