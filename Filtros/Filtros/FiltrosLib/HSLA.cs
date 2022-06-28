using System;
using System.Collections.Generic;
using System.Text;

namespace FilterLib
{
    public struct HSLA
    {
        public double h, s, l, a;

        public HSLA(double H, double S, double L, double A)
        {
            h = H;
            s = S;
            l = L;
            a = A;
        }

        public RGBA ToRGBA()
        {
            RGBA result = new RGBA(0,0,0,0);
            if (0 == s)           
                result.r = result.g = result.b = l; // achromatic         
            else
            {
                double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;
                result.r = hue2rgb(p, q, h + 1.0/ 3);
                result.g = hue2rgb(p, q, h);
                result.b = hue2rgb(p, q, h - 1.0/ 3);
            }
            result.a = a;
            return result;
        }

        private static double hue2rgb(double p, double q, double t)
        {
            if (t < 0)
                t += 1;
            if (t > 1)
                t -= 1;
            if (t < 1.0/ 6)
                return p + (q - p) * 6 * t;
            if (t < 1.0/ 2)
                return q;
            if (t < 2.0/ 3)
                return p + (q - p) * (2.0/ 3 - t) * 6;
            return p;
        }
    }
}
