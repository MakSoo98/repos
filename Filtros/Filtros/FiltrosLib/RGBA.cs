
namespace FilterLib
{
    public struct RGBA
    {
        public double r, g, b, a;

        public RGBA(double R, double G, double B, double A)
        {
            r = R;
            g = G;
            b = B;
            a = A;
        }

        public int IntR
        {
            get
            {
                int result = (int)(r * 255);
                if (result > 255)
                    return 255;
                if (result < 0)
                    return 0;
                return result;
            }
        }

        public int IntG
        {
            get
            {
                int result = (int)(g * 255);
                if (result > 255)
                    return 255;
                if (result < 0)
                    return 0;
                return result;
            }
        }

        public int IntB
        {
            get
            {
                int result = (int)(b * 255);
                if (result > 255)
                    return 255;
                if (result < 0)
                    return 0;
                return result;
            }
        }

        public int IntA
        {
            get
            {
                int result = (int)(a * 255);
                if (result > 255)
                    return 255;
                if (result < 0)
                    return 0;
                return result;
            }
        }

        public RGBA GetNegative()
        {
            return new RGBA(1 - r, 1 - g, 1 - b, a);
        }

        public HSLA ToHSL()
        {
            HSLA result = new HSLA(0, 0, 0, 0);
            double max = System.Math.Max(System.Math.Max(r, g), b);
            double min = System.Math.Min(System.Math.Min(r, g), b);
            result.h = result.s = result.l = (max + min) / 2;
            if (max == min)
                result.h = result.s = 0;
            else
            {
                double d = max - min;
                result.s = (result.l > 0.5) ? d / (2 - max - min) : d / (max + min);
                if (max == r)
                    result.h = (g - b) / d + (g < b ? 6 : 0);
                else if (max == g)
                    result.h = (b - r) / d + 2;
                else if (max == b)
                    result.h = (r - g) / d + 4;
                result.h /= 6;
            }
            result.a = a;
            return result;
        }

        public static RGBA operator +(RGBA a, RGBA b)
        {
            return new RGBA(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
        }

        public static RGBA operator *(RGBA a, double b)
        {
            return new RGBA(a.r + b, a.g + b, a.b + b, a.a + b);
        }

        public static RGBA operator *(RGBA a, RGBA b)
        {
            return new RGBA(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
        }

        public static RGBA operator -(RGBA a)
        {
            return new RGBA(-a.r, -a.g, -a.b, -a.a);
        }
        public static RGBA operator !(RGBA a)
        {
            return a.GetNegative();
        }

        /*
        public static HSLA operator =(RGBA a)
        {
            return a.ToHSL();
        }
        */
    }
}
