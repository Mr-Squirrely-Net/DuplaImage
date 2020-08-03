using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using HandyControl.Controls;

namespace DuplaImage.API {
    internal static class Reference {
        internal static string Image { get; set; }
        internal static List<ulong> HashList { get; } = new List<ulong>();
        internal static List<DImage> Images { get; } = new List<DImage>();
        internal static List<string> FileList { get; } = new List<string>();
        internal static PopupWindow popup = new PopupWindow() {
            Title = "Scanning",
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            ShowInTaskbar = false,
            AllowsTransparency = true,
            WindowStyle = WindowStyle.None
        };
    }
}
