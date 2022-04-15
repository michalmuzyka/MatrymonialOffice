using System;
using MatrymonialOffice.Data;

namespace MatrymonialOffice.Alghoritms
{
    public static class Affilations
    {
        public static double Identity(ValueType actual, (Importance importance, ValueType? value) desired)
        {
            if (desired.importance == Importance.Unimportant) 
                return 1;

            return Equals(actual, desired.value) ? 1 : 0;
        } 
        public static double Age(int actual, (int min, int max) desired)
        {
            if (actual >= desired.min && actual <= desired.max)
                return 1;

            double m = (desired.max - desired.min)/ 2;

            if (actual > desired.max)
                return Math.Max((actual + desired.min - m) / m, 0);

            return Math.Max((actual - desired.min + m) / m, 0);
        }
        public static double Height(int actual, int desired) => 1.0 / (1.0 + Math.Pow((actual - desired) / 4.0, 2));
        public static double Residence((double Latitude, double Longitude) actual, (double Latitude, double Longitude) desired) => 1.0 / (1.0 + Math.Pow(Coordinates.Distance(actual, desired) / 10, 2));
        public static double Earnings(int actual, (int min, int max) desired)
        {
            if (actual >= desired.min && actual <= desired.max)
                return 1;

            double m = (desired.max - desired.min) / 2;

            if (actual > desired.max)
                return Math.Max((actual + desired.min - m) / m, 0);

            return Math.Max((actual - desired.min + m) / m, 0);
        }
        public static double Attractiveness(int actual, int desired)
        {
            if (actual <= desired - 3)
                return 0;
            
            if (actual >= desired)
                return 1;

            return (actual - desired + 3) / 3.0;
        }
        public static double ImportanceParameters(int actual, int desired) => (5 - Math.Abs(desired - actual)) / 5;
    }
}
