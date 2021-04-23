using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Common
{
    public static class ModelConstants
    {
        public static readonly int MaxSectionRows = 100;
        public static readonly int MinSectionRows = 1;

        public static readonly int MaxSectionColumns = 10;
        public static readonly int MinSectionColumns = 1;

        public static readonly int AirportNameLength = 3;
        public static readonly int AirlineNameMaxLegth = 6;

        public static readonly string NamePattern = "^[A-Z]+$";

    }
}
