using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Models
{
    public class Seat
    {
        public Seat(int seatRow , char seatColumnCharacter)
        {
            this.Row = seatRow;
            this.Col = seatColumnCharacter;
        }
        public int Row { get; set; }
        public char Col { get; set; }
        public bool IsBooked { get; set; } = false;

        public string Id {
            get
            {
                return this.Row.ToString() + this.Col.ToString();
            } 
        }
    }
}
