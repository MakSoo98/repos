using System;
using System.Collections.Generic;
using System.Text;

namespace UnProyectoQueQuieroHacerFuncionar
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
    }
}
