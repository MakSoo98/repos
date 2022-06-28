

namespace FilterLib
{
    public class Filter
    {
        public static Image<RGBA> ConverToGrayScale(Image<RGBA> source, int Type)
        {
            Image<RGBA> destination = Image<RGBA>.CreateImage(source.Width, source.Height);
            for(int x = 0; x < source.Width; x++)
            {
                for(int y = 0; y < source.Height; y++)
                {
                    RGBA aux = source[x, y];                        
                    double num = (aux.r + aux.g + aux.b)/3;
                    RGBA c = new RGBA(num, num, num, aux.a);
                    destination[x, y] = c;
                }
            }
            return destination;         
        }
        private static RGBA PixelAvg(int x, int y, Image<RGBA> img, int kernel)
        {
            RGBA aux2 = new RGBA(0,0,0,0);
            int range2 = kernel * kernel;
            int range = kernel / 2;
            for (int i = x - range; i <= x + range; i++)
            {
                for (int j = y - range; j <= y + range; j++)
                {                
                    RGBA Avg = img[i, j];
                    double avgR = Avg.r / range2 + aux2.r;
                    double avgG = Avg.g / range2 + aux2.g;
                    double avgB = Avg.b / range2 + aux2.b;
                    double avgA = Avg.a / range2 + aux2.a;
                    aux2 = new RGBA(avgR, avgG, avgB, avgA);
                }
            }
            return aux2;
        }

        public static Image<RGBA> Blur(Image<RGBA> source,int kernel)
        {
            Image<RGBA> destination = Image<RGBA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    RGBA b = PixelAvg(x, y, source, kernel);
                    destination[x, y] = b;
                }
            }
            return destination;
        }

        public static Image<RGBA> TurnNegative(Image<RGBA> source)
        {
            Image<RGBA> destination = Image<RGBA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < destination.Width; x++)
            {
                for (int y = 0; y < destination.Height; y++)
                {
                    RGBA b = source[x, y];
                    RGBA aux = b.GetNegative();
                    destination[x, y] = aux;
                }
            }
            return destination;
        }

        public static Image<HSLA> ConvertToHSLA(Image<RGBA> source)
        {
            Image<HSLA> destination = Image<HSLA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < destination.Width; x++)
            {
                for (int y = 0; y < destination.Height; y++)
                {
                    RGBA b = source[x, y];
                    HSLA aux = b.ToHSL();
                    destination[x, y] = aux;
                }
            }
            return destination;
        }

        public static Image<RGBA> ConvertToRGBA(Image<HSLA> source)
        {
            Image<RGBA> destination = Image<RGBA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < destination.Width; x++)
            {
                for (int y = 0; y < destination.Height; y++)
                {
                    HSLA b = source[x, y];
                    RGBA aux = b.ToRGBA();
                    destination[x, y] = aux;
                }
            }
            return destination;
        }

        public static Image<double> GetChannelHSLA(Image<HSLA> source, int Channel)
        {
            Image<double> destination = Image<double>.CreateImage(source.Width, source.Height);
            switch (Channel)
            {         
                case 0:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            HSLA aux = source[x, y];
                            destination[x, y] = aux.h;
                        }
                    }
                    return destination;
                case 1:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            HSLA aux = source[x, y];                            
                            destination[x, y] = aux.s;
                        }
                    }
                    return destination;
                case 2:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            HSLA aux = source[x, y];
                            destination[x, y] = aux.l;
                        }
                    }
                    return destination;
                case 3:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            HSLA aux = source[x, y];
                            destination[x, y] = aux.a;
                        }
                    }
                    return destination;
                default:
                    return null;
            };            
        }

        public static Image<double> GetChannelRGBA(Image<RGBA> source, int Channel)
        {
            Image<double> destination = Image<double>.CreateImage(source.Width, source.Height);
            switch (Channel)
            {
                case 0:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            RGBA aux = source[x, y];
                            destination[x, y] = aux.r;
                        }
                    }
                    return destination;
                case 1:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            RGBA aux = source[x, y];
                            destination[x, y] = aux.g;
                        }
                    }
                    return destination;
                case 2:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            RGBA aux = source[x, y];
                            destination[x, y] = aux.b;
                        }
                    }
                    return destination;
                case 3:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            RGBA aux = source[x, y];
                            destination[x, y] = aux.a;
                        }
                    }
                    return destination;
                default:
                    return null;
            };
        }

        public static Image<HSLA> ReplaceChannel(Image<HSLA> source, Image<double> image, int channel)
        {
            Image<HSLA> destination = Image<HSLA>.CreateImage(source.Width, source.Height);
            switch (channel)
            {
                case 0:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            double aux = image[x,y];
                            HSLA aux2 = new HSLA(aux, source[x, y].s, source[x, y].l, source[x, y].a);
                            destination[x, y] = aux2;
                        }
                    }
                    return destination;
                case 1:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            double aux = image[x, y];
                            HSLA aux2 = new HSLA(source[x, y].h, aux, source[x, y].l, source[x, y].a);
                            destination[x, y] = aux2;
                        }
                    }
                    return destination;
                case 2:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            double aux = image[x, y];
                            HSLA aux2 = new HSLA(source[x, y].h, source[x, y].s, aux, source[x, y].a);
                            destination[x, y] = aux2;
                        }
                    }
                    return destination;
                case 3:
                    for (int x = 0; x < destination.Width; x++)
                    {
                        for (int y = 0; y < destination.Height; y++)
                        {
                            double aux = image[x, y];
                            HSLA aux2 = new HSLA(source[x, y].h, source[x, y].s, source[x, y].s, aux);
                            destination[x, y] = aux2;
                        }
                    }
                    return destination;
                default:
                    return null;
            };
        }

        public static Image<HSLA> AdjustHistogram(Image<HSLA> source, double AddS, double MulS, double AddL, double MulL)
        {
            Image<HSLA> destination = Image<HSLA>.CreateImage(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                for(int x = 0; x < source.Width; x++)
                {
                    HSLA p = source[x, y];
                    p.s += AddS;
                    p.s *= MulS;
                    p.l += AddL;
                    p.l *= MulL;
                    destination[x, y] = p;
                }
            }
            return destination;
        }

        private static RGBA PixelSum(int x, int y, Image<RGBA> img, Image<double> kernel)
        {
            RGBA aux2 = new RGBA(0, 0, 0, 0);
            int h = kernel.Height;
            int w = kernel.Width;
            int h_offset = h / 2;
            int w_offset = w / 2;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int source_X = x + i - w_offset;
                    int source_Y = y + j - h_offset;
                    RGBA Avg = img[source_X,source_Y];
                    double aux = kernel[i, j];
                    double avgR = Avg.r * aux + aux2.r;
                    double avgG = Avg.g * aux + aux2.g;
                    double avgB = Avg.b * aux + aux2.b;
                    aux2 = new RGBA(avgR, avgG, avgB, Avg.a);
                }
            }
            return aux2;
        }

        public static Image<RGBA> BlurGus(Image<RGBA> source, Image<double> kernel)
        {
            Image<RGBA> destination = Image<RGBA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    RGBA b = PixelSum(x,y,source, kernel);
                    destination[x, y] = b;
                }
            }
            return destination;
        }

         /*public static Image<double> CreateKernel(int width, int height)
         {
             Image<double> destination = Image<double>.CreateImage(width, height);
             for (int y = 0; y < destination.Height; y++)
             {
                 for (int x = 0; x < destination.Width; x++)
                 {
                     if ((x == 0 && y == 0) || (x == 2 && y == 0) || (x == 0 && y == 2) || (x == 2 && y == 2))
                         destination[x, y] = 0.025;
                     else if ((x == 1 && y == 0) || (x == 0 && y == 1) || (x == 2 && y == 1) || (x == 1 && y == 2))
                         destination[x, y] = 0.1;
                     else
                         destination[x, y] = 0.5;
                 }
             }
             return destination;
         }*/

        public static Image<double> CreateKernel()
        {
            Image<double> destination = Image<double>.CreateImage(3, 3);
            destination[0, 0] = 0.025;
            destination[0, 1] = 0.1;
            destination[0, 2] = 0.025;
            destination[1, 0] = 0.1;
            destination[1, 1] = 0.5;
            destination[1, 2] = 0.1;
            destination[2, 0] = 0.025;
            destination[2, 1] = 0.1;
            destination[2, 2] = 0.025;
            return destination;
        }

        public static Image<HSLA> RotateHue(Image<HSLA> source, double offset)
        {
            Image<HSLA> destination = Image<HSLA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    HSLA c = source[x, y];
                    HSLA b = new HSLA(c.h + offset,c.s,c.l,c.a);
                    if (b.h > 1)                  
                        b.h -= System.Math.Floor(b.h);           
                    else if (b.h < 0)
                    {
                        while (b.h < 0)
                            b.h += 1;
                    }
                    destination[x, y] = b;
                }
            }
            return destination;
        }

        public static Image<HSLA> CreateIHueBlobps(Image<HSLA> source, double hue_min, double hue_max, double sat_min, double sat_max, double lum_min, double lum_max)
        {
            Image<HSLA> destination = Image<HSLA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    HSLA c = source[x, y];
                    if((hue_min <= c.h && c.h <= hue_max) && (sat_min <= c.s && c.s <= sat_max) && (lum_min <= c.l && c.l <= lum_max))
                        destination[x, y] = new HSLA(1.0, 1.0, 1.0, 1.0);
                    else
                        destination[x, y] = new HSLA(0.0, 1.0, 0.0, 1.0);
                }
            }
            return destination;
        }

        public static Image<HSLA> DIlate(Image<HSLA> source)
        {
            Image<HSLA> destination = Image<HSLA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    HSLA b = GetPixelsArround(source,x, y, 11);
                    destination[x, y] = b;
                }
            }
            return destination;
        }

        private static HSLA GetPixelsArround(Image<HSLA> image,int x, int y, int kernel)
        {
            HSLA p = image[x,y];
            int aux = kernel / 2;          
            for (int i = y - aux; i < y + aux; i++)
            {
                for(int j = x - aux; j < x + aux; j++)
                {
                    HSLA c = image[j, i];
                    if (c.l > p.l)
                        p = c;
                }
            }
            return p;
        }

        public static Image<int> ConvertToBinary(Image<HSLA> source)
        {
            Image<int> destination = Image<int>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    HSLA b = source[x, y];
                    int aux;
                    if (b.l < 0.5)
                        aux = 0;
                    else
                        aux = 1;
                    destination[x, y] = aux;
                }
            }
            return destination;
        }

        public static Image<RGBA> BinaryToRGBA(Image<int> source)
        {
            Image<RGBA> destination = Image<RGBA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    int b = source[x, y];
                    RGBA aux;
                    if (b == 0)
                        aux = new RGBA(0, 0, 0, 1);
                    else
                        aux = new RGBA(1, 1, 1, 1);
                    destination[x, y] = aux;
                }
            }
            return destination;
        }

        public static Image<int> GroupBlops(Image<int> source)
        {
            Image<int> destination = source;
            const int InitalBlop = 1;
            int aux = InitalBlop + 1;
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    int b = destination[x, y];
                    if (b != InitalBlop)
                    { 
                        AssignBlopNumber(destination, x, y, b, aux);
                        aux++;
                    }        
                }
            }
            return destination;
        }

        private static void AssignBlopNumber(Image<int> aux ,int x, int y, int pixel,int constant)
        {
            pixel = constant;        
            int izq = aux[x - 1, y];
            int der = aux[x + 1, y];
            int arr = aux[x, y + 1];
            int abj = aux[x, y - 1];
            int arrder = aux[x + 1, y + 1];
            int arrizq = aux[x - 1, y + 1];
            int abjder = aux[x + 1, y - 1];
            int abjizq = aux[x - 1, y - 1];
            if (izq != 0 && izq != constant)
                AssignBlopNumber(aux, x - 1, y, pixel, constant);
            else if (arrizq != 0 && arrizq != constant)
                AssignBlopNumber(aux, x - 1, y + 1, pixel, constant);
            else if (arr != 0 && arr != constant)
                AssignBlopNumber(aux, x, y + 1, pixel, constant);
            else if (arrder != 0 && arrder != constant)
                AssignBlopNumber(aux, x + 1, y + 1, pixel, constant);
            else if (der != 0 && der != constant)
                AssignBlopNumber(aux, x + 1, y, pixel, constant);
            else if (abjder != 0 && abjder != constant)
                AssignBlopNumber(aux, x + 1, y - 1, pixel, constant);
            else if (abj != 0 && abj != constant)
                AssignBlopNumber(aux, x, y - 1, pixel, constant);
            else if (abjizq != 0 && abjizq != constant)
                AssignBlopNumber(aux, x - 1, y - 1, pixel, constant);
            else
                return;          
        }
        public static Image<RGBA> TransfromGroupsToImage(Image<int> source)
        {
            Image<RGBA> destination = Image<RGBA>.CreateImage(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    int b = source[x, y];
                    if (b == 0)
                        destination[x, y] = new RGBA(0, 0, 0, 1);
                    else if (b == 1)
                        destination[x, y] = new RGBA(1, 1, 1, 1);
                    else if (b == 2)
                        destination[x, y] = new RGBA(1, 0, 0, 1);
                    else
                        destination[x, y] = new RGBA(0, 1, 0, 1);                   
                }
            }
            return destination;
        }        
    }
}
