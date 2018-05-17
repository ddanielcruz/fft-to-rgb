namespace FFTtoRGB.Color
{
    /// <summary>
    /// RGB color to pass to the Arduino UNO
    /// </summary>
    public class RGB
    {
        private int _red = 0;
        public int Red
        {
            get => _red;
            set
            {
                if (value >= 0 && value <= 255)
                    _red = value;
                else
                    throw new InvalidColorValueException();
            }
        }

        private int _green = 0;
        public int Green
        {
            get => _green;
            set
            {
                if (value >= 0 && value <= 255)
                    _green = value;
                else
                    throw new InvalidColorValueException();
            }
        }

        private int _blue = 0;
        public int Blue
        {
            get => _blue;
            set
            {
                if (value >= 0 && value <= 255)
                    _blue = value;
                else
                    throw new InvalidColorValueException();
            }
        }

        public RGB()
        {
        }
        public RGB(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
        public RGB(int X, int Y, int Z, Order order)
        {
            switch (order)
            {
                case Order.RGB:
                    Red = X;
                    Green = Y;
                    Blue = Z;
                    break;

                case Order.RBG:
                    Red = X;
                    Blue = Y;
                    Green = Z;
                    break;

                case Order.GRB:
                    Green = X;
                    Red = Y;
                    Blue = Z;
                    break;

                case Order.GBR:
                    Green = X;
                    Blue = Y;
                    Red = Z;
                    break;

                case Order.BRG:
                    Blue = X;
                    Red = Y;
                    Green = Z;
                    break;

                case Order.BGR:
                    Blue = X;
                    Green = Y;
                    Red = Z;
                    break;
            }
        }

        public override string ToString() => $"[{Red}, {Green}, {Blue}]";
    }
}
