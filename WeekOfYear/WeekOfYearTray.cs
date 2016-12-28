using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Hardcodet.Wpf.TaskbarNotification;
using WeekOfYear.Properties;

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
            SetWeekOfYear();
            NotifyIcon.ContextMenu = CreateContextMenu(); 
        }

        ~WeekOfYearTrayInstance()
        {
            Settings.Default.Save();
            ConfigureStartOnWindowsStartUp();
        }

        private static ContextMenu CreateContextMenu()
        {
            var contextMenu = new ContextMenu();

            var headerMenuItem = new MenuItem
            {
                Header = $"WeekOfYear ({NotifyIcon.ToolTipText})",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                StaysOpenOnClick = true
            };

            var startOnWindowsStartGrid = new StartOnWindowsStartopMenuItemContent();
            var startOnWindowsStartGridMenuItem = new MenuItem
            {
                Header = startOnWindowsStartGrid,
                ToolTip = "Check if you want WeekOfYear to start on Windows startup",
                StaysOpenOnClick = true
            };

            var closeMenuItem = new MenuItem
            {
                Header = "Close",
                ToolTip = "Terminate WeekOfYear"
            };
            closeMenuItem.Click += delegate { Application.Current.Shutdown(); };

            contextMenu.Items.Add(headerMenuItem);
            contextMenu.Items.Add(startOnWindowsStartGridMenuItem);
            contextMenu.Items.Add(closeMenuItem);
            return contextMenu;
        }

        private static void ConfigureStartOnWindowsStartUp()
        {
            try
            {
                var key =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                var curAssembly = Assembly.GetExecutingAssembly();

                if (Settings.Default.StartOnWindowsStartup)
                {
                    key?.SetValue(curAssembly.GetName().Name, curAssembly.Location);
                }
                else
                {
                    key?.DeleteValue(curAssembly.GetName().Name, false);
                }
            }
            catch (Exception) { /* bla */ }
        }

        public void Start()
        {
            DispatcherTimer.Start();
        }

        private static void DispatcherTimerOnTick(object sender, EventArgs eventArgs)
        {
            SetWeekOfYear();
            NotifyIcon.ContextMenu = CreateContextMenu();
        }

        private static void SetWeekOfYear()
        {
            var weekOfYear = DateTime.Now.WeekOfYearIso8601().ToString();
            NotifyIcon.ShowText(weekOfYear);
            NotifyIcon.ToolTipText = $"{weekOfYear}. week";
        }
    }
}