
namespace FilterLib
{
    public class Image<T>
    {
        private int width, height;
        private T[] pixel;

        private Image(int NewWidth, int NewHegiht)
        {
            width = NewWidth;
            height = NewHegiht;
            pixel = new T[width * height];
        }

        public int Width 
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public T this[int x, int y]
        {
            get 
            {
                return GetPixelAt(x, y);
            }
            set 
            {
                SetPixel(x, y, value);
            }

        }

        public static Image<T> CreateImage(int NewWidht, int NewHeight)
        {
            if(NewHeight <= 0 || NewWidht <= 0)
            {
                return null;
            }
            return new Image<T>(NewWidht, NewHeight);
        }

        public T GetPixelAt(int X, int Y)
        {
            if (X < 0)
                X = 0;
            else if (X >= width)
                X = width - 1;
            if (Y < 0)
                Y = 0;
            else if (Y >= height)
                Y = height - 1;
            return pixel[Y * width + X];
        }

        public void SetPixel(int X, int Y, T P)
        {
            if (X < 0)
                return;
            else if (X >= width)
                return;
            if (Y < 0)
                return;
            else if (Y >= height)
                return;
            pixel[Y * width + X] = P;
        }

        public void Fill(T P)
        {
            for(int i = 0; i < pixel.Length; i++)
            {
                pixel[i] = P;
            }
        }

        public void FillRectangle(int X, int Y, int Width, int Height, T P)
        {
            for(int i = Y; i < Y + Height ; i++)
            {
                for(int j = X;  j < X + Width; j++)
                {
                    SetPixel(j, i, P);
                }
            }
        }

        /* public void Multiply(RGBA P)
         {
             for(int i = 0; i < pixel.Length; i++)
             {
                 RGBA aux = new RGBA(pixel[i].r * P.r, pixel[i].g * P.g, pixel[i].b * P.b, pixel[i].a * P.a);
                 pixel[i] = aux;
             }
         }

         public void Add(RGBA P)
         {
             for (int i = 0; i < pixel.Length; i++)
             {
                 RGBA aux = new RGBA(pixel[i].r + P.r, pixel[i].g + P.g, pixel[i].b + P.b, pixel[i].a + P.a);
                 pixel[i] = aux;
             }
         }*/
    }
}
