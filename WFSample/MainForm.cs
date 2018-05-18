using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FFTtoRGB;
using FFTtoRGB.Color;

namespace WFSample
{
    public partial class MainForm : Form
    {
        private RGBGenerator Generator { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Generator = new RGBGenerator();
            Generator.ColorGenerated += OnColorGenerated;
        }

        private void OnStartClicked(object sender, EventArgs e) => Generator.Run();
        private void OnStopClicked(object sender, EventArgs e) => Generator.Stop();
        private void OnNextClicked(object sender, EventArgs e) => Generator.Settings.Order = SwitchColor();

        private Order SwitchColor()
        {
            switch (Generator.Settings.Order)
            {
                case Order.RGB:
                    return Order.RBG;
                case Order.RBG:
                    return Order.GRB;
                case Order.GRB:
                    return Order.GBR;
                case Order.GBR:
                    return Order.BRG;
                case Order.BRG:
                    return Order.BGR;
                default:
                    return Order.RGB;
            }           
        }

        private void OnColorGenerated(object sender, GenericEventArgs<RGB> e)
        {
            var color = e.Data;
            panel.BackColor = Color.FromArgb(color.Red, color.Green, color.Blue);
        }        

        private void OnXValueChanged(object sender, EventArgs e)
        {
            if (scrollX.Value <= scrollY.Value)
                Generator.Settings.X = scrollX.Value / 100.0;
            else
                scrollX.Value = scrollY.Value;
        }

        private void OnYValueChanged(object sender, EventArgs e)
        {
            if (scrollY.Value >= scrollX.Value)
                Generator.Settings.Y = scrollY.Value / 100.0;
            else
                scrollY.Value = scrollX.Value;
        }
    }
}
