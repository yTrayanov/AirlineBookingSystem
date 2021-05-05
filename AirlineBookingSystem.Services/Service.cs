namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using System.ComponentModel.DataAnnotations;

    public class Service
    {
        protected Service(BaseContext context)
        {
            this.Context = context;
        }

        protected BaseContext Context { get; set; }

        protected void ValidateModel(object obj)
        {
            var context = new ValidationContext(obj);
            Validator.ValidateObject(obj, context, true);
        }
    }
}
