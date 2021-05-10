namespace AirlineBookingSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Seat : BaseModel
    {
        public Seat(int seatRow, char seatColumnCharacter)
        {
            this.Row = seatRow;
            this.Col = seatColumnCharacter;
        }

        [Key]
        public int Id { get; set; }

        public int Row { get; set; }
        public char Col { get; set; }
        public bool IsBooked { get; set; } = false;

        public string SeatNumber
        {
            get
            {
                return this.Row.ToString() + this.Col.ToString();
            }
        }
    }
}
