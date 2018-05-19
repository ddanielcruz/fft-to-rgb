using FFTtoRGB;
using FFTtoRGB.Color;
using System;
using System.Drawing;
using System.Windows.Forms;
using Transmitter;

namespace WFSample
{
    public partial class MainForm : Form
    {
        private SerialTransmitter Transmitter { get; set; }
        private bool IsConfigured { get; set; } = false;

        private RGBGenerator Generator { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Generator = new RGBGenerator();
            Generator.ColorGenerated += OnColorGenerated;
        }

        private void OnColorGenerated(object sender, GenericEventArgs<RGB> e)
        {
            var color = e.Data;

            // Set demoPanel's BackColor
            demoPanel.BackColor = Color.FromArgb(color.Red, color.Green, color.Blue);

            // TODO Send data to Arduino
        }

        // Generator Start and Stop
        private void OnStartClicked(object sender, EventArgs e) => Generator.Run();
        private void OnStopClicked(object sender, EventArgs e) => Generator.Stop();

        // Scroll X
        private void OnXValueChanged(object sender, EventArgs e)
        {
            if (scrollX.Value <= scrollY.Value)
                Generator.Settings.X = scrollX.Value / 100.0;
            else
                scrollX.Value = scrollY.Value;
        }

        // Scroll Y
        private void OnYValueChanged(object sender, EventArgs e)
        {
            if (scrollY.Value >= scrollX.Value)
                Generator.Settings.Y = scrollY.Value / 100.0;
            else
                scrollY.Value = scrollX.Value;
        }

        // Order Color Buttons
        private void RGBChecked(object sender, EventArgs e) => Generator.Settings.Order = Order.RGB;
        private void RBGChecked(object sender, EventArgs e) => Generator.Settings.Order = Order.RBG;
        private void GRBChecked(object sender, EventArgs e) => Generator.Settings.Order = Order.GRB;
        private void GBRChecked(object sender, EventArgs e) => Generator.Settings.Order = Order.GBR;
        private void BRGChecked(object sender, EventArgs e) => Generator.Settings.Order = Order.BRG;
        private void BGRChecked(object sender, EventArgs e) => Generator.Settings.Order = Order.BGR;

        // Arduino
        private void OnOpenClicked(object sender, EventArgs e)
        {
            if (!Transmitter.IsOpen)
                Transmitter.Open();
        }
        private void OnCloseClicked(object sender, EventArgs e)
        {
            if (Transmitter.IsOpen)
                Transmitter.Close();
        }

        private void OnConfigureClicked(object sender, EventArgs e)
        {
            var form = new Settings();
            form.OnSuccess += OnSuccess;
            form.FormClosed += (s, ev) => Enabled = true;

            Enabled = false;
            form.Show();
        }

        private void OnSuccess(object sender, GenericEventArgs<SerialTransmitter> e)
        {
            Transmitter = e.Data;
            btnOpen.Enabled = true;
            btnClose.Enabled = true;
        }
    }
}
