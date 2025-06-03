using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Autoclicker
{
    public partial class Form1 : Form {

        private Autoclicker autoclicker = new Autoclicker(10); // Default CPS set to 10
        private int clickingTime = 0;
        public Form1() {
            InitializeComponent();
        }


        private void StartBtn_Click(object sender, EventArgs e) {
            autoclicker.StartClicking();
            startBtn.Enabled = false; // Disable the start button to prevent multiple instances

            if (clickingTime > 0) {
                Thread.Sleep(clickingTime * 1000); // Convert seconds to milliseconds
                autoclicker.StopClicking();
                startBtn.Enabled = true; // Re-enable the start button after the time has elapsed
                Debug.WriteLine("Clicking stopped");
            }
            else {
                Debug.WriteLine("Clicking will continue until stopped manually.");
            }
        }

        private void StopBtn_Click(object sender, EventArgs e) {
            autoclicker.StopClicking();
            startBtn.Enabled = true; // Re-enable the start button after stopping
        }

        private void UpdateBtn_Click(object sender, EventArgs e) {
            int cpsValue = int.TryParse(cpsTextBox.Text, out int result) ? result : 0; // Default to 10 if parsing fails
            clickingTime = int.TryParse(timeTextBox.Text, out result) ? result : 0; // Default to 0 if parsing fails
            autoclicker.UpdateAutoclicker(cpsValue);
        }

        private void AAfkBtn_Click(object sender, EventArgs e) {
            Debug.WriteLine("This button is not implemented yet.");
        }

    }
}
