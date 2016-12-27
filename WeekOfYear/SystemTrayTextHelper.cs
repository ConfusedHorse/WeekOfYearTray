using System.Drawing;
using Hardcodet.Wpf.TaskbarNotification;
using Brushes = System.Drawing.Brushes;
using FontStyle = System.Drawing.FontStyle;

namespace WeekOfYear
{
    internal static class SystemTrayTextHelper
    {
        public static void ShowText(this TaskbarIcon notifyIcon, string text)
        {
            var bitmap = new Bitmap(16, 16);
            var graphics = Graphics.FromImage(bitmap);
            var brush = Brushes.White;
            var font = new Font("Segoe UI", 8.25f, FontStyle.Regular);
            graphics.DrawString(text, font, brush, 0, 0);
            
            var hIcon = bitmap.GetHicon();
            var icon = Icon.FromHandle(hIcon);
            notifyIcon.Icon = icon;

        }
    }
}