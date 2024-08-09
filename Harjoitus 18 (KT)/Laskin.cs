// Tiedosto: Laskin.cs

using System;

namespace WpfLaskin
{
    public static class Laskin
    {
        public static double Summa(double a, double b)
        {
            return a + b;
        }

        public static double Erotus(double a, double b)
        {
            return a - b;
        }

        public static double Jakolasku(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Nollalla ei voi jakaa.");
            return a / b;
        }
        //jep jep jep
        public static double Kertolasku(double a, double b)
        {
            return a * b;
        }
    }
}
