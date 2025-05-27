using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
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

        //    INPUT inp = new INPUT();
        //    inp.type = 0;
        //    MOUSEINPUT mi = new MOUSEINPUT();
        //    mi.dx = 0;
        //    mi.dy = 0;
        //    mi.dwFlags = 0x0002; // MOUSEEVENTF_LEFTDOWN
        //    mi.mouseData = 0;
        //    mi.time = 0;
        //    mi.dwExtraInfo = UIntPtr.Zero;

        //    inp.u.mi = mi;

        //    INPUT inp2 = new INPUT();
        //    inp2.type = 0;
        //    MOUSEINPUT mi2 = mi;
        //    mi2.dwFlags = 0x0004; // MOUSEEVENTF_LEFTUP
        //    inp2.u.mi = mi2;

        //    INPUT[] pInputs = { inp, inp2 };

        //    MessageBox(IntPtr.Zero, "Somet's gone wrong, Gromit", "'ELP!", 0);
        //    for (int i = 0; i < 10000; i++) {
        //        Thread.Sleep(10);
        //        SendInput(2, pInputs, Marshal.SizeOf(typeof(INPUT)));
        //        Console.WriteLine("M Down");
        //    }


            // I feel very dumb for mixing up the mouse data and flags input in the constructors have been debugging for a while

            MOUSEINPUT mi = new MOUSEINPUT(0, 0, 0, 0x0002, 0, UIntPtr.Zero);
            INPUT inp = new INPUT();
            inp.type = 0;
            inp.u.mi = mi;

            MOUSEINPUT mi2 = new MOUSEINPUT(0, 0, 0, 0x0004, 0, UIntPtr.Zero);
            INPUT inp2 = new INPUT {
                type = 0
            };
            inp2.u.mi = mi2;


            INPUT[] pInputs = { inp, inp2 };

            for(int i = 0; i < 10000; i++) {
                Thread.Sleep(10);
                SendInput(2, pInputs, Marshal.SizeOf(typeof(INPUT)));
                Console.WriteLine("M Down");
            }
        }

    }
}
