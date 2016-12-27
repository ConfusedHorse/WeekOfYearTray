using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Hardcodet.Wpf.TaskbarNotification;

namespace WeekOfYear
{
    internal class WeekOfYearTrayInstance
    {
        private static readonly TaskbarIcon NotifyIcon = new TaskbarIcon();
        private static readonly DispatcherTimer DispatcherTimer 
            = new DispatcherTimer {Interval = TimeSpan.FromHours(1)};

        public WeekOfYearTrayInstance()
        {
            DispatcherTimer.Tick += DispatcherTimerOnTick;
            NotifyIcon.ContextMenu = CreateContextMenu(); 
            SetWeekOfYear();
        }

        private static ContextMenu CreateContextMenu()
        {
            var contextMenu = new ContextMenu();
            var closeMenuItem = new MenuItem
            {
                Header = "Close",
                ToolTip = "Terminate WeekOfYear"
            };
            closeMenuItem.Click += delegate { Application.Current.Shutdown(); };
            contextMenu.Items.Add(closeMenuItem);
            return contextMenu;
        }

        public void Start()
        {
            DispatcherTimer.Start();
        }

        private static void DispatcherTimerOnTick(object sender, EventArgs eventArgs)
        {
            SetWeekOfYear();
        }

        private static void SetWeekOfYear()
        {
            var weekOfYear = DateTime.Now.WeekOfYearIso8601().ToString();
            NotifyIcon.ShowText(weekOfYear);
            NotifyIcon.ToolTipText = $"{weekOfYear}. week of {DateTime.Now.Year}";
        }
    }
}