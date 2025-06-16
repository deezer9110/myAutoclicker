using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Autoclicker {
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT {
        public int x;
        public int y;

        public POINT(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public POINT GetPOINT() {
            return new POINT(x, y);
        }
    }

    [StructLayout(LayoutKind.Sequential)] // SEQUENTIAL = fields are laid out in the order they are declared
    public struct MOUSEINPUT {

        public int dx; // x movement
        public int dy; // y movement
        public uint mouseData; // scroll wheel / buttons data
        public uint dwFlags; // specifies type of mouse action
        public uint time; // lets system timestamp the event, normally 0
        public UIntPtr dwExtraInfo; // optional app defined ptr that's rarely used

        public MOUSEINPUT(POINT p, uint mouseData, uint dwFlags, uint time, UIntPtr dwExtraInfo) {
            dx = p.x;
            dy = p.y;
            this.mouseData = mouseData;
            this.dwFlags = dwFlags;
            this.time = time;
            this.dwExtraInfo = dwExtraInfo;
        }

        public MOUSEINPUT(int dx, int dy, uint mouseData, uint dwFlags, uint time, UIntPtr dwExtraInfo) {
            this.dx = dx;
            this.dy = dy;
            this.mouseData = mouseData;
            this.dwFlags = dwFlags;
            this.time = time;
            this.dwExtraInfo = dwExtraInfo;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT {
        ushort wVk;  
        ushort wScan; 
        uint dwFlags; 
        uint time; 
        UIntPtr dwExtraInfo; 

        public KEYBDINPUT(ushort wVk, ushort wScan, uint dwFlags, uint time, UIntPtr dwExtraInfo) {
            this.wVk = wVk;
            this.wScan = wScan;
            this.dwFlags = dwFlags;
            this.time = time;
            this.dwExtraInfo = dwExtraInfo;
        }   
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT {
        public uint type; // 0 for mouse input, 1 for keyboard input
        public INPUT_UNION u; // 

        public INPUT(uint type, INPUT_UNION u) {
            this.type = type;
            this.u = u;
        }
    }

    [StructLayout(LayoutKind.Explicit)] // EXPLICIT = fields are laid out at specific offsets
    public struct INPUT_UNION {
        [FieldOffset(0)] public MOUSEINPUT mi; // mouse input
        [FieldOffset(0)] public KEYBDINPUT ki; // keyboard input
    }
}
