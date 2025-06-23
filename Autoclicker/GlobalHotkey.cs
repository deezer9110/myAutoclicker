using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Autoclicker {
    // This class implements a global hotkey using a low-level keyboard hook
    // It uses the same code as Stephen Toub's article on low-level keyboard hooks:
    // https://learn.microsoft.com/en-us/archive/blogs/toub/low-level-keyboard-hook-in-c
    // I used it to understand how to implement my own version
    internal class GlobalHotkey {


        private const int WH_KEYBOARD_LL = 13; // Low-level keyboard hook
        private const int WM_KEYDOWN = 0x0100; // Key down message
        private const int WM_KEYUP = 0x0101; // Key up message
        private LLKeyboardProc proc; // Delegate for the hook callback
        private IntPtr hookID = IntPtr.Zero; // Hook ID for the low-level keyboard hook
        private HashSet<Keys> pressedKeys; // Tracks of currently pressed keys
        // A HashSet is the same as a hash table but doesn't store keys, only values, and no duplicates
        private Autoclicker autoclicker;
        private int aCRunning = 0;
        private Form1 form;

        public GlobalHotkey(Autoclicker autoclicker, Form1 form) {

            // Variable initialization
            this.autoclicker = autoclicker;
            pressedKeys = new();
            proc = HookCallback;
            hookID = SetHook();
            this.form = form;
        }

        private IntPtr SetHook() {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) {
                // Set the low-level keyboard hook
                // Sets the hook as a low level keyboard one, using the delegated LLKeyBoard procedure in the current module
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LLKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            // If nCode is less than 0, the hook procedure must pass the message
            if (nCode >= 0) {

                int vkCode = Marshal.ReadInt32(lParam); // Read the virtual key code from the lParam

                if (wParam == (IntPtr)WM_KEYDOWN) {
                    pressedKeys.Add((Keys)vkCode);
                }
                if(wParam == (IntPtr)WM_KEYUP) {
                    pressedKeys.Remove((Keys)vkCode);
                }

                if (pressedKeys.Contains(Keys.LControlKey) && pressedKeys.Contains(Keys.LShiftKey) && pressedKeys.Contains(Keys.A)) {
                    Console.WriteLine("Shortcut pressed");
                    // Example: Ctrl + Shift + A is pressed, logic goes under
                    if(aCRunning == 0) {
                        // If autoclicker is not running, start it
                        autoclicker.StartClicking();
                        aCRunning = 1; // Set the flag to indicate that autoclicker is running
                        Debug.WriteLine("Global Hotkey Ctrl + Shift + A pressed - Autoclicker started");
                        form.GetStartBtn().Enabled = false; // Disable the start button
                    } else {
                        autoclicker.StopClicking();
                        aCRunning = 0; // Reset the flag to indicate that autoclicker is stopped
                        Debug.WriteLine("Global Hotkey Ctrl + Shift + A pressed - Autoclicker stopped");
                        form.GetStartBtn().Enabled = true; // Re-enable the start button
                    }
                }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        public void Unhook() {
            // Unhooks the low-level keyboard hook
            if (hookID != IntPtr.Zero) {
                UnhookWindowsHookEx(hookID);
                hookID = IntPtr.Zero;
            }
        }


        // DllImport statements for WAPI functions, referenced from Stephen Toub's article: 
        // https://learn.microsoft.com/en-us/archive/blogs/toub/low-level-keyboard-hook-in-c

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        // Sets the Windows hook for low level keyboard events
        private static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardProc longPtrToFunction, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        // Unhooks the Windows hook set by SetWindowsHookEx
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        // Calls the next hook in the chain
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        // Gets the module handle for the current process by its name
        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}
