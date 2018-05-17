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

        /// <summary>
        /// First limit value, used to take values from the FFT array from zero to (Lenght * X) position
        /// </summary>
        public double X { get; set; } = 33.3;

        /// <summary>
        /// Second limit value, used to take values from the FFT array from (Lenght * X) to (Lenght * Y) position
        /// </summary>
        public double Y { get; set; } = 66.6;

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
