namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class Service
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

        protected void HasKey(ICollection<string> keys ,string name, bool shouldContain , string errorMessage)
        {
            if (keys.Contains(name) != shouldContain)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
