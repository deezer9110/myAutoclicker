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


        private void StartBtn_Click(object sender, EventArgs e) {
            autoclicker.StartClicking();

            if (clickingTime > 0) {
                Thread.Sleep(clickingTime * 1000); // Convert seconds to milliseconds
                autoclicker.StopClicking();
                ToggleStartBtn(); // Re-enable the start button after the time has elapsed
                Debug.WriteLine("Clicking stopped");
            } else {
                Debug.WriteLine("Clicking will continue until stopped manually.");
                ToggleStartBtn();
            }
        }

        public void ToggleStartBtn() {
            startBtn.Enabled = !startBtn.Enabled; // Toggle the start button state
        }

        private void StopBtn_Click(object sender, EventArgs e) {
            autoclicker.StopClicking();
            startBtn.Enabled = true; // Re-enable the start button after stopping
        }

        private void UpdateBtn_Click(object sender, EventArgs e) {
            int cpsValue = int.TryParse(cpsTextBox.Text, out int result) ? result : 10; // Default to 10 if parsing fails
            clickingTime = int.TryParse(timeTextBox.Text, out result) ? result : 0; // Default to 0 if parsing fails
            autoclicker.UpdateAutoclicker(cpsValue);
        }

        private void AAfkBtn_Click(object sender, EventArgs e) {

            switch (aAfkToggle) {

                case 0:
                    autoclicker.AntiAfk();
                    aAfkToggle = 1; // Toggle on
                    Debug.WriteLine("AA Toggle on");
                    break;

                case 1:

                    autoclicker.AntiAfkStop(); // Assuming you have a method to stop anti-AFK actions
                    aAfkToggle = 0; // Toggle off
                    Debug.WriteLine("AA Toggle off");

                    break;
            }
        }

    }
}
