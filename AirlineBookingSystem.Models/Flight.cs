using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineBookingSystem.Models
{
    public class Flight
    {
        private Airport _destinationAirtport;
        private DateTime _departureDate;
        private string _id;

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

        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Flight id is required");
                }

                if(value.Contains(" "))
                {
                    throw new ArgumentException("Flight id can't contain whitespace");
                }

                this._id = value;
            }
        }

        public Airline Airline { get; set; }
        public Airport OriginAirport { get; set; }
        public Airport DestinationAirport
        {
            get
            {
                return this._destinationAirtport;
            }
            set
            {
                if (value == this.OriginAirport)
                {
                    throw new ArgumentException("Destination airport must be diffrent from origin airport");
                }
                this._destinationAirtport = value;
            }
        }

        public List<FlightSection> Sections { get; set; }


        /// <summary>
        ///  Checks if there is an available seats in any section
        /// </summary>
        public bool hasAvalableSeats
        {
            get
            {
                if (this.Sections.Any())
                {
                    for (int i = 0; i < this.Sections.Count; i++)
                    {
                        var currentSectionSeats = this.Sections[i].Seats;

                        for (int row = 0; row < currentSectionSeats.GetLength(0); row++)
                        {
                            for (int col = 0; col < currentSectionSeats.GetLength(1); col++)
                            {
                                if (!currentSectionSeats[row, col].IsBooked)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                return false;
            }
        }

        public string DepartureDate
        {
            get
            {
                return _departureDate.ToString("MM/dd/yyyy");
            }
        }


    }
}
