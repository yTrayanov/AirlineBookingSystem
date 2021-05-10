namespace AirlineBookingSystem.Services
{
    using AirlineBookingSystem.Data;
    using System;
    using System.Collections.Generic;

    public abstract class Service
    {
        protected Service(BaseContext context)
        {
            this.Context = context;
        }

        protected BaseContext Context { get; set; }

        protected void ShouldContainKey(ICollection<string> keys, string key, bool shouldContain, string errorMessage)
        {
            if (keys.Contains(key) != shouldContain)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
