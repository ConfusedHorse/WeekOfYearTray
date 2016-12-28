using System.Windows;
using System.Windows.Controls;
using WeekOfYear.Properties;

namespace WeekOfYear
{
    /// <summary>
    /// Interaction logic for StartOnWindowsStartopMenuItemContent.xaml
    /// </summary>
    public partial class StartOnWindowsStartopMenuItemContent : UserControl
    {
        public StartOnWindowsStartopMenuItemContent()
        {
            InitializeComponent();
            StartOnWindowsStartupCheckBox.IsChecked = Settings.Default.StartOnWindowsStartup;
        }

        private void StartOnWindowsStartupCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            Settings.Default.StartOnWindowsStartup = true;
        }

        private void StartOnWindowsStartupCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            Settings.Default.StartOnWindowsStartup = false;
        }
    }
}
