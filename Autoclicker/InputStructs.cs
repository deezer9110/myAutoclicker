using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Autoclicker {

    [StructLayout(LayoutKind.Sequential)] // SEQUENTIAL = fields are laid out in the order they are declared
    public struct MOUSEINPUT {
        int dx; // x movement
        int dy; // y movement
        uint mouseData; // scroll wheel / buttons data
        uint dwFlags; // specifies type of mouse action
        uint time; // lets system timestamp the event, normally 0
        IntPtr dwExtraInfo; // optional app defined ptr that's rarely used

        public void setPosition(int x, int y) {
            dx = x;
            dy = y;
        }

        public void setMouseData(uint data) {
            mouseData = data;
        }

        public void setFlags(uint flags) {
            dwFlags = flags;
        }

        public void setTime(uint time) {
            this.time = time;
        }

        public void setExtraInfo(IntPtr extraInfo) {
            dwExtraInfo = extraInfo;
        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT {
        ushort wVk;  
        ushort wScan; 
        uint dwFlags; 
        uint time; 
        IntPtr dwExtraInfo; 
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT {
        public uint type; // 0 for mouse input, 1 for keyboard input
        public INPUT_UNION u; // 
    }

    [StructLayout(LayoutKind.Explicit)] // EXPLICIT = fields are laid out at specific offsets
    public struct INPUT_UNION {
        [FieldOffset(0)] public MOUSEINPUT mi; // mouse input
        [FieldOffset(0)] public KEYBDINPUT ki; // keyboard input
    }
}
