using System;

namespace MatrymonialOffice.Data
{
    public static class Coordinates
    {
        public static double Distance((double Latitude, double Longitude) c1, (double Latitude, double Longitude) c2)
        {
            const int EarthsRadius = 6371;
            double degreeToRadians(double degree) => degree * Math.PI / 180;

            double latitude1 = degreeToRadians(c1.Latitude);
            double latitude2 = degreeToRadians(c2.Latitude);
            double longitude1 = degreeToRadians(c1.Longitude);
            double longitude2 = degreeToRadians(c2.Longitude);

            double latitudeDiff = latitude1 - latitude2;
            double longitudeDiff = longitude1 - longitude2;

            double formula = Math.Pow(Math.Sin(latitudeDiff/2), 2) + Math.Cos(latitude1) * Math.Cos(latitude2) * Math.Pow(Math.Sin(longitudeDiff/2), 2);

            return 2 * EarthsRadius * Math.Asin(Math.Sqrt(formula));
        }
    }
}
