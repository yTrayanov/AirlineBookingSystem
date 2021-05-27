namespace AirlineBookingSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel
    {
        protected void Validate()
        {
            var context = new ValidationContext(this);
            Validator.ValidateObject(this, context, true);
        }
    }
}
