using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Autoclicker {
    public partial class Form1 : Form {

        private Autoclicker autoclicker; // Default CPS set to 10
        private int aAfkToggle; // Toggle for Anti-AFK functionality
        private int clickingTime;
        private GlobalHotkey gH;

        public Form1() {
            InitializeComponent();
            autoclicker = new(10);
            aAfkToggle = 0;
            clickingTime = 0;
            gH = new(autoclicker, this); // Initialize the global hotkey
        }

        public void Form1_Unload(object sender, FormClosingEventArgs e) {
            gH.Unhook();
            Debug.WriteLine("Global hotkey unhooked");
        }

        public Button GetStartBtn() {
            return startBtn; // Return the start button for external access if needed
        }

        private void StartBtn_Click(object sender, EventArgs e) {

            autoclicker.StartClicking();

            if (clickingTime > 0) {
                // Clicking time is set route
                gH.Unhook(); // Unhook the global hotkey to prevent conflicts

                startBtn.Enabled = false;
                Thread.Sleep(clickingTime * 1000); // Convert seconds to milliseconds for click time duration

                autoclicker.StopClicking();
                startBtn.Enabled = true; // Re-enable the start button after the time has elapsed
                Debug.WriteLine("Clicking stopped");

                gH = new(autoclicker, this); // Reinitialize the global hotkey after stopping clicking
            } else {
                // No clicking time set route
                Debug.WriteLine("Clicking will continue until stopped manually.");
                startBtn.Enabled = false;
            }
        }

        private void StopBtn_Click(object sender, EventArgs e) {
            autoclicker.StopClicking();
            startBtn.Enabled = true; // Re-enable the start button after stopping
        }

        private void ResetButtons(object sender, EventArgs e) {
            startBtn.Enabled = true; // Re-enable the start button
            if (aAfkToggle == 1)
                AAfkBtn_Click(sender, e); // Toggle Anti-AFK off if it was on
        }

        private void UpdateBtn_Click(object sender, EventArgs e) {
            int cpsValue = int.TryParse(cpsTextBox.Text, out int result) ? result : 10; // Default to 10 if parsing fails
            clickingTime = int.TryParse(timeTextBox.Text, out result) ? result : 0; // Default to 0 if parsing fails
            autoclicker.UpdateAutoclicker(cpsValue);
            ResetButtons(sender, e);
        }

        private void AAfkBtn_Click(object sender, EventArgs e) {

            switch (aAfkToggle) {

                case 0:
                    autoclicker.AntiAfk();
                    aAfkBtn.ForeColor = Color.Green; // Change button color to show it's on
                    aAfkToggle = 1; // Toggle on
                    Debug.WriteLine("AA Toggle on");
                    break;

                case 1:

                    autoclicker.AntiAfkStop(); // Assuming you have a method to stop anti-AFK actions
                    aAfkBtn.ForeColor = Color.Red; // Change button color to show it's off
                    aAfkToggle = 0; // Toggle off
                    Debug.WriteLine("AA Toggle off");

                    break;
            }
        }

    }
}
