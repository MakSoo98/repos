using System;
using System.Collections.Generic;
using System.Text;

namespace madmax_pero_que_funciona
{
    class Utils
    {
        private static Random random = new Random();

        public static double GetRandom(double min, double max)
        {
            return (random.NextDouble() * (max - min)) + min;
        }

        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }
        public static double GetDistance(double PosA,double PosB)
        {
            return Math.Abs(PosA - PosB);
        }
    }
}
