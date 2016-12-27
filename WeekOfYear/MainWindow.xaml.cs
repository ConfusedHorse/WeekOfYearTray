using System.Windows;

namespace WeekOfYear
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var instance = new WeekOfYearTrayInstance();
            instance.Start();
            InitializeComponent();
        }
    }
}
