using System;
using System.Reflection;
using System.Windows;

namespace WeekOfYear
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private App()
        {
            try
            {
                var key =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                var curAssembly = Assembly.GetExecutingAssembly();
                
                key?.SetValue(curAssembly.GetName().Name, curAssembly.Location);
            }
            catch (Exception) { /* bla */ }
        }
    }
}
