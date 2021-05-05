namespace AirlineBookingSystem.Models
{
    using AirlineBookingSystem.Models.CustomAttributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    public class Flight
    {
        private DateTime _departureDate;

        public Flight(Airline airline, Airport originAirport
            , Airport destinationAirport, DateTime departureDate, string id)
        {
            this.Id = id;
            this.Airline = airline;
            this.OriginAirport = originAirport;
            this.DestinationAirport = destinationAirport;
            this._departureDate = departureDate;
            this.Sections = new List<FlightSection>();

        }

        [Required(ErrorMessage = "Flight id is required")]
        public string Id { get; set; }

        public Airline Airline { get; set; }
        public Airport OriginAirport { get; set; }

        
        [NotEqual(nameof(OriginAirport))]
        public Airport DestinationAirport { get; set; }

        public List<FlightSection> Sections { get; set; }

        public string DepartureDate
        {
            get
            {
                return _departureDate.ToString("MM/dd/yyyy");
            }
        }

        public bool IsAvailable
        {
            get
            {
                if (this.Sections.Any())
                {
                    for (int i = 0; i < this.Sections.Count; i++)
                    {
                        var currentSectionSeats = this.Sections[i];
                        if (currentSectionSeats.hasAvailableSeats)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        


    }
}
