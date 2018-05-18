using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FFTtoRGB;
using FFTtoRGB.Color;
using FFTtoRGB.FFT;

namespace WFSample
{
    public partial class MainForm : Form
    {
        private RGBGenerator Generator { get; set; }

        public MainForm()
        {
            InitializeComponent();
            var config = new FFTProviderConfig { SampleTake = SampleTakeMeasure.Quarter };
            Generator = new RGBGenerator(config)
            {
                Settings = new ColorSettings(Order.BRG, 0.05, 0.6)
            };
            Generator.ColorGenerated += OnColorGenerated;
        }

        private void OnStartClicked(object sender, EventArgs e) => Generator.Run();
        private void OnStopClicked(object sender, EventArgs e) => Generator.Stop();

        private void OnColorGenerated(object sender, GenericEventArgs<FFTtoRGB.Color.RGB> e)
        {
            var color = e.Data;
            panel.BackColor = Color.FromArgb(color.Red, color.Green, color.Blue);
        }
    }
}
