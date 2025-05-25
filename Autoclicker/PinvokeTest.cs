using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Autoclicker {

    internal class PinvokeTest {

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);


        public static void runTest() {


            INPUT inp = new INPUT();
            inp.type = 0;
            MOUSEINPUT mi = new MOUSEINPUT();
            mi.setPosition(0, 0);
            mi.setFlags(0x0002); // MOUSEEVENTF_LEFTDOWN
            mi.setMouseData(0);
            mi.setTime(0);
            mi.setExtraInfo(IntPtr.Zero);

            inp.u.mi = mi;

            INPUT[] pInputs = { inp };

            MessageBox(IntPtr.Zero, "Somet's gone wrong, Gromit", "'ELP!", 0);
            for(int i = 0; i < 10000; i++) {
                SendInput(1, pInputs, Marshal.SizeOf(typeof(INPUT)));
                Console.WriteLine("M Down");
            }
        }

    }
}
