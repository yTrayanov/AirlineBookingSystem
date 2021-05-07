namespace AirlineBookingSystem.Models
{
    using AirlineBookingSystem.Models.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FlightSection
    {
        public FlightSection(int rows, int columns, SeatClass seatClass)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.SeatClass = seatClass;
            GenerateSeats();
        }


        [Key]
        public int Id { get; set; }

        public Seat[,] Seats { get; set; }

        [Range(ModelConstants.MinSectionRows, ModelConstants.MaxSectionRows,
            ErrorMessage = "Invalid rows number")]
        public int Rows { get; set; }

        [Range(ModelConstants.MinSectionColumns, ModelConstants.MaxSectionColumns,
            ErrorMessage = "Invalid columns number")]
        public int Columns { get; set; }

        public SeatClass SeatClass { get; set; }

        public bool hasAvailableSeats
        {
            get
            {
                for (int row = 0; row < this.Seats.GetLength(0); row++)
                {
                    for (int col = 0; col < this.Seats.GetLength(1); col++)
                    {
                        if (!this.Seats[row, col].IsBooked)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        private void GenerateSeats()
        {
            this.Seats = new Seat[this.Rows, this.Columns];

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    this.Seats[row, col] = new Seat(row + 1, Convert.ToChar(col + 'A'));
                }
            }

        }

    }
}
