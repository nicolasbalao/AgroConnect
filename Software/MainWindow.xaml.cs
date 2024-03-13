using Contracts.Dtos;
using Software.Services;
using Software.ViewModels;
using Software.Views;
using System.Windows;
using System.Windows.Input;

namespace Software
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var globalStateService = new GlobalState();
            InitializeComponent();
            DataContext = new MainViewModel(globalStateService);
            ((MainViewModel)DataContext).NavigateCommand.Execute("Employees");

        }


     
        private void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.P && Keyboard.Modifiers == ModifierKeys.Control)
            {
                MainViewModel dataContext = this.DataContext as MainViewModel;
                dataContext.ShowAdminAuthWindow("");
            }

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var test = await  HttpService.Get<DepartmentDto[]>("departments");


        }
    }
}