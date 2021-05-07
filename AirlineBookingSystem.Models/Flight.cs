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
            this.Sections = new Dictionary<SeatClass, FlightSection>();

        }

        [Required(ErrorMessage = "Flight id is required")]
        public string Id { get; set; }

        public Airline Airline { get; set; }
        public Airport OriginAirport { get; set; }

        
        [NotEqual(nameof(OriginAirport))]
        public Airport DestinationAirport { get; set; }

        public Dictionary<SeatClass ,FlightSection> Sections { get; set; }


        [NotPastDate]
        public string DepartureDate
        {
            get
            {
                return _departureDate.ToString("dd/MM/yyyy");
            }
        }

        public bool IsAvailable
        {
            get
            {
                if (this.Sections.Any())
                {
                    foreach (var section in this.Sections.Values)
                    {
                        if (section.hasAvailableSeats)
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
