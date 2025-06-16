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
        private INPUT[] pInputs = new INPUT[2];
        private INPUT[] pInputs2 = new INPUT[1];
        private CancellationTokenSource ctsClick;
        private CancellationTokenSource ctsAAfk;
        private Random rnd = new();

        public Autoclicker(int initialCPS) {
            SetCPS(initialCPS);
            ctsClick = new CancellationTokenSource(); // Initialize the CancellationTokenSource for clicking
            ctsAAfk = new CancellationTokenSource(); // Initialize the CancellationTokenSource for Anti-AFK
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

        public void CreateInputsClick() {

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

        public void CreateInputsKeyBD(uint action, ushort keyCode) {

            KEYBDINPUT ki;
            INPUT_UNION u;
            INPUT inp;

            pInputs2 = new INPUT[1]; // Reset the array for Anti-AFK inputs


            ki = new(keyCode, 0, action, 0, UIntPtr.Zero);
            u = new INPUT_UNION { ki = ki };
            inp = new(1, u);

            pInputs2[0] = inp;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        private void Click() {
            CreateInputsClick();
            if (SendInput(2, pInputs, Marshal.SizeOf<INPUT>()) != 2) {
                Debug.WriteLine("Error sending input: " + Marshal.GetLastWin32Error());
                return;
            } else {
                Debug.WriteLine("Click sent successfully.");
            }
        }

        private void AAMove() {
            uint[] actions = { 0x0, 0x0002 }; // KEYDOWN and KEYUP respectively
            ushort[] keys = { 0x41, 0x44 }; // A and D keys

            // Nested for loop to iterate through key down and key up of actions for A and D keys
            for (int i = 0; i < 2; i++) {
                for(int j = 0; j < 2; j++) {

                    CreateInputsKeyBD(actions[j], keys[i]);

                    if (SendInput(1, pInputs2, Marshal.SizeOf<INPUT>()) != 1) {
                        Debug.WriteLine("Error sending input: " + Marshal.GetLastWin32Error());
                        return;
                    } else {
                        Debug.WriteLine("Anti-AFK move sent successfully.");
                    }

                    if (actions[j] == 0)
                        Thread.Sleep(3000);
                    
                }
            }

        }

        public void StartClicking() {

            var token = ctsClick.Token;

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
            ctsClick?.Cancel(); // Using ?, it checks the nullability of cts instead of an if statement or exception or something else
            ctsClick = new(); // Reset for future use
        }

        // Would work for things that are text based, but not for games that require an input with functions like
        // GetASyncKeyState, which wouldn't intake a simulated key press as valid movement
        public void AntiAfk() {

            var token = ctsAAfk.Token;

            Task.Run(async () => {
                while (!token.IsCancellationRequested) {
                    int timeBetween = rnd.Next(10000, 30000);
                    AAMove();
                    await Task.Delay(timeBetween);
                }
            });

        }

        public void AntiAfkStop() {
            ctsAAfk?.Cancel(); // Cancel the Anti-AFK task if it's running
            ctsAAfk = new(); // Reset for future use
        }
    }
}
