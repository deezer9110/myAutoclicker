using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Autoclicker {

    internal class PinvokeTest {

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        public static void runTest() {
            // Invoke the function as a regular managed method.
            MessageBox(IntPtr.Zero, "Somet's gone wrong, Gromit", "'ELP!", 0);
        }

    }
}
