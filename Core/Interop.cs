﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LeagueSharp.Loader.Core
{
    internal static class Interop
    {
        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam,
            ref COPYDATASTRUCT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam,
            ref COPYDATASTRUCT lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        internal static void SendWindowMessage(IntPtr wnd, WindowMessageTarget channel, string data)
        {
            var lParam = new COPYDATASTRUCT {cbData = (int) channel, dwData = data.Length*2 + 2, lpData = data};
            SendMessage(wnd, 74U, IntPtr.Zero, ref lParam);
        }

        internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        internal struct COPYDATASTRUCT
        {
            public int cbData;
            public int dwData;
            [MarshalAs(UnmanagedType.LPWStr)] public string lpData;
        }

        internal enum WindowMessageTarget
        {
            AppDomain = 1,
            Core = 2
        }
    }
}