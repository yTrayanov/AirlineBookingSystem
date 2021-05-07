namespace AirlineBookingSystem.Models
{
    using AirlineBookingSystem.Models.Constants;
    using System.ComponentModel.DataAnnotations;

    public class Airport
    {
        public Airport(string airportName)
        {
            this.Name = airportName;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Airport name is required")]
        [StringLength(ModelConstants.AirportNameLength, MinimumLength = ModelConstants.AirportNameLength, ErrorMessage = "Flight name must consist of 3 alphabetic upper cased characters")]
        [RegularExpression(ModelConstants.NamePattern, ErrorMessage = "Name should contain only uppercased letters!")]
        public string Name { get; set; }
    }
}
