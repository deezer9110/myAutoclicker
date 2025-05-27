using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Autoclicker {
    internal static class GetCursorPosTest {

        // WORKS LIKE A DREAM! Turns out to test console output properly ur meant to
        // change the property of the application to make it a console app and not a windows one, OOPS

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetCursorPos(out POINT lpPoint);

        public static void runTest() {
            POINT p;
            if (GetCursorPos(out p)) {
                Console.WriteLine("x: " + p.x + "\ny: " + p.y);
            } else {
                Console.WriteLine("Failed to get cursor position.");
            }
        }

    }
}
