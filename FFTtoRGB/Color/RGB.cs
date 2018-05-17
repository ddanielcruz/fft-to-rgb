namespace FFTtoRGB.Color
{
    /// <summary>
    /// RGB color to pass to the Arduino UNO
    /// </summary>
    public class RGB
    {
        private uint _red;
        public uint Red
        {
            get => _red;
            set
            {
                if (value <= 255)
                    _red = value;
                else
                    throw new InvalidColorValueException();
            }
        }

        private uint _green;
        public uint Green
        {
            get => _green;
            set
            {
                if (value <= 255)
                    _green = value;
                else
                    throw new InvalidColorValueException();
            }
        }

        private uint _blue;
        public uint Blue
        {
            get => _blue;
            set
            {
                if (value <= 255)
                    _blue = value;
                else
                    throw new InvalidColorValueException();
            }
        }

        public RGB()
        {
        }
        public RGB(uint red, uint green, uint blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
