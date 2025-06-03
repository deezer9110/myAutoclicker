using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Autoclicker {
    internal class Autoclicker {

        private int clicksPerSec;
        private System.Timers.Timer clickTimer = new();
        private INPUT[] pInputs = new INPUT[2];
        private CancellationTokenSource cts;

        public Autoclicker(int initialCPS) {
            SetCPS(initialCPS);
            cts = new CancellationTokenSource(); // Initialize the CancellationTokenSource
        }

        public void SetCPS(int initialCPS) {
            clicksPerSec = initialCPS > 0 ? initialCPS : 0; // One line code to ensure non-negative value, like an if statement
        }
        public int GetCPS() {
            return clicksPerSec;
        }
        
        public void UpdateAutoclicker(int newCPS) {
            if (newCPS > 0) {
                SetCPS(newCPS);
            }
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


        public void Click() {
            createInputs();
            if (SendInput(2, pInputs, Marshal.SizeOf<INPUT>()) != 2) {
                Debug.WriteLine("Error sending input: " + Marshal.GetLastWin32Error());
                return;
            } else {
                Debug.WriteLine("Click sent successfully.");
            }
        }

        public void StartClicking() {

            var token = cts.Token;

            // Use a lambda to handle the logic
            // Using async = asynchronous method to allow for delays without blocking other threads, like the UI in forms
            // Task is just used to keep the method in the background and is a better alternative to a timer
            Task.Run(async () => {
                while (!token.IsCancellationRequested) {
                    Click();
                    await Task.Delay(1000 / clicksPerSec);
                }
            });
        }

        public void StopClicking() {
            cts?.Cancel(); // Using ?, it checks the nullability of cts instead of an if statement or exception or something else
            cts = new(); // Reset for future use
        }

        public void AntiAfk() {

        }
    }
}
