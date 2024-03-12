using Software.ViewModels;
using System.Windows;

namespace Software
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            ((MainViewModel)DataContext).NavigateCommand.Execute("Employees");

        }
    }
}