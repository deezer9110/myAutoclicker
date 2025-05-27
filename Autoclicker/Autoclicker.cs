using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Autoclicker {
    internal class Autoclicker {

        private int clicksPerSec;
        private System.Timers.Timer clickTimer;
        private INPUT[] pInputs;

        public Autoclicker(int initialCPS) {
            setCPS(initialCPS);
            createTimer();
        }

        public void createTimer() {
            clickTimer = new System.Timers.Timer(1000.0 / clicksPerSec);
        }

        public void destroyTimer() {
            clickTimer.Stop();
            clickTimer.Dispose(); 
        }
        public void setCPS(int initialCPS) {
            clicksPerSec = initialCPS > 0 ? initialCPS : 0; // One line code to ensure non-negative value, like an if statement
        }
        public int getCPS() {
            return clicksPerSec;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetCursorPos(out POINT lpPoint);

        public void createInputs() {

            GetCursorPos(out POINT p);

            pInputs = new INPUT[2];

            MOUSEINPUT mi = new(p.x, p.y, 0, 0x0002, 0, UIntPtr.Zero);
            INPUT_UNION u = new INPUT_UNION { mi = mi };
            INPUT inp = new(0, u);

            MOUSEINPUT mi2 = new(p.x, p.y, 0, 0x0004, 0, UIntPtr.Zero);
            INPUT_UNION u2 = new INPUT_UNION { mi = mi2 };
            INPUT inp2 = new(0, u2);

            pInputs[0] = inp;
            pInputs[1] = inp2;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);


        public void click(object? sender, ElapsedEventArgs e) {

            createInputs();
            if(SendInput(2, pInputs, Marshal.SizeOf<INPUT>()) != 2)
                Console.WriteLine("Error sending input: " + Marshal.GetLastWin32Error());
            else
                Console.WriteLine("Click");
        }

        public void startClicking() {
            clickTimer.Elapsed += click;

            clickTimer.AutoReset = true;
            clickTimer.Enabled = true;

            Console.WriteLine("Clicking started at rate: " + clicksPerSec);
        }

        public void stopClicking() {
            clickTimer.Enabled = false;
        }

        public bool increaseCPS(int val) {
            if (clicksPerSec > 0 && val > 0)
                clicksPerSec += val;
            else
                return false;
            return true;
        }
        public bool decreaseCPS(int val) {
            if (clicksPerSec > 0 && val > 0)
                clicksPerSec -= val;
            else
                return false;
            return true;
        }
    }
}
