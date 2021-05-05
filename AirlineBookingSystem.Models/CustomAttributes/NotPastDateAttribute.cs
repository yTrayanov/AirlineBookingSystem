using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirlineBookingSystem.Models.CustomAttributes
{
    public class NotPastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            if(Convert.ToDateTime(value) < DateTime.Now)
            {
                throw new ValidationException("Can't create flights with past date");
            }

            return true;
        }
    }
}
