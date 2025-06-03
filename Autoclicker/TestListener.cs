using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Autoclicker {
    internal class TestListener {

        // THIS CODE DOESN'T WORK - It uses GetAsyncKeyState, but a hook is superior for multiple key combinations

        [DllImport("User32.dll")]
        static extern short GetAsyncKeyState(Int32 vKey);
        const int VK_SHIFT = 0x10;
        const int VK_CONTROL = 0x11;
        const int VK_A = 0x41;
        const int VK_C = 0x43;

        public static void runTest() {
            while (true) {
                short keyStatus = GetAsyncKeyState(VK_SHIFT);
                short controlStatus = GetAsyncKeyState(VK_CONTROL);
                // short aStatus = GetAsyncKeyState(VK_A);
                // short cStatus = GetAsyncKeyState(VK_C);

                if ((keyStatus & controlStatus & 1) == 1) {
                    Console.WriteLine("WABAM");
                    break;
                }
            }
        }
    }
}
