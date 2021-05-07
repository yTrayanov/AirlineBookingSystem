namespace AirlineBookingSystem.Models
{
    using AirlineBookingSystem.Models.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Airline
    {
        public Airline(string name)
        {
            this.Name = name;
            this.Flights = new List<Flight>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Airline name is required")]
        [MaxLength(ModelConstants.AirlineNameMaxLegth , ErrorMessage ="Airline must be less then 6 alphabetic symbols")]
        [RegularExpression(ModelConstants.NamePattern , ErrorMessage ="Invalid Airline format")]
        public string Name{ get; set; }

        public List<Flight> Flights { get; set; }
    }
}
