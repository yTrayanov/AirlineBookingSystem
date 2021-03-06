namespace AirlineBookingSystem.Models
{
    using AirlineBookingSystem.Common;
    using System;

    public class FlightSection
    {
        private int _rows;
        private int _columns;

        public FlightSection(int rows, int columns, SeatClass seatClass)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.SeatClass = seatClass;
            GenerateSeats();
        }


        public Seat[,] Seats { get; set; }

        public int Rows
        {
            get
            {
                return this._rows;
            }
            set
            {
                if (value > ModelConstants.MaxSectionRows || value < ModelConstants.MinSectionRows)
                {
                    throw new ArgumentException($"There can't be more than {ModelConstants.MaxSectionRows} and less than {ModelConstants.MinSectionRows}");
                }
                this._rows = value;
            }
        }
        public int Columns
        {
            get
            {
                return this._columns;
            }
            set
            {
                if (value > ModelConstants.MaxSectionColumns || value < ModelConstants.MinSectionColumns)
                {
                    throw new ArgumentException($"There can't be more than {ModelConstants.MaxSectionColumns} and less than {ModelConstants.MinSectionColumns} columns");
                }
                this._columns = value;
            }
        }

        public SeatClass SeatClass { get; set; }

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
