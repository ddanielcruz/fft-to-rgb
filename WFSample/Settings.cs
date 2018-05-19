using FFTtoRGB;
using System;
using System.Linq;
using System.Windows.Forms;
using Transmitter;

namespace WFSample
{
    public partial class Settings : Form
    {
        public event EventHandler<GenericEventArgs<SerialTransmitter>> OnSuccess;
        private SerialTransmitter _transmitter { get; set; }

        private string BaudText { get; set; } = string.Empty;

        public Settings() => InitializeComponent();

        private void OnBaudChanged(object sender, EventArgs e)
        {
            if (IsDigitsOnly(txtBaud.Text))
                BaudText = txtBaud.Text;
            else
                txtBaud.Text = BaudText;
        }
        bool IsDigitsOnly(string str) => str.All(char.IsDigit);

        private void OnConfirmClicked(object sender, EventArgs e)
        {
            var port = txtPort.Text;
            //MessageBox.Show("Message", "Title", MessageBoxButtons.OK);
            if (!string.IsNullOrWhiteSpace(port))
            {
                int baudRate = 9600;

                if (!string.IsNullOrWhiteSpace(BaudText))
                    baudRate = Convert.ToInt32(BaudText);

                // TODO Check it this port belongs to an Arduino
                _transmitter = new SerialTransmitter(port, baudRate);
                OnSuccess?.Invoke(this, new GenericEventArgs<SerialTransmitter>(_transmitter));
                Close();
            }
            else
                MessageBox.Show("Port field must be filled", "Missing field!", MessageBoxButtons.OK);
        }
    }
}
