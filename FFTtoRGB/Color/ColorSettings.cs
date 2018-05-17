namespace FFTtoRGB.Color
{
    /// <summary>
    /// Color percentage distribution used to generate the RGB color
    /// </summary>
    public class ColorSettings
    {
        /// <summary>
        /// Settings' order
        /// </summary>
        public Order Order { get; set; } = Order.RGB;

        private double _x = 0.33;
        /// <summary>
        /// First limit value, used to take values from the FFT array from zero to (Length * X) position
        /// The value must be between zero and 1.
        /// </summary
        public double X
        {
            get => _x;
            set
            {
                if (value >= 0 && value <= 1)
                    _x = value;
                else
                    throw new InvalidSettingsValueException();
            }
        }

        private double _y = 0.66;
        /// <summary>
        /// Second limit value, used to take values from the FFT array from (Length * X) to (Length * Y) position.
        /// The value must be between zero and 1.
        /// </summary>
        public double Y
        {
            get => _y;
            set
            {
                if (value >= 0 && value <= 1)
                    _y = value;
                else
                    throw new InvalidSettingsValueException();
            }
        }

        public ColorSettings()
        {
        }
        public ColorSettings(Order order, double x, double y)
        {
            Order = order;
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Possible orders to distribute colors
    /// </summary>
    public enum Order
    {
        RGB = 0,
        RBG = 1,
        GRB = 2,
        GBR = 3,
        BRG = 4,
        BGR = 5
    }
}
