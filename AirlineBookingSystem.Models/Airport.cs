namespace AirlineBookingSystem.Models
{
    using AirlineBookingSystem.Common;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class Airport
    {
        public Airport(string airportName)
        {
            this.Name = airportName;
        }

        [Required(ErrorMessage = "Airport name is required")]
        [StringLength(ModelConstants.AirportNameLength, MinimumLength = ModelConstants.AirportNameLength, ErrorMessage = "Flight name must consist of 3 alphabetic upper cased characters")]
        [RegularExpression(ModelConstants.NamePattern, ErrorMessage = "Name should contain only uppercased letters!")]
        public string Name { get; set; }
    }
}
