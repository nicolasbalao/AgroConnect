using System.Windows.Input;
using Software.Views;

namespace Software.ViewModels
{
    internal class MainViewModel : ViewModelBase 
    {

        public ICommand NavigateCommand { get; }

        public MainViewModel()
        {
            NavigateCommand = new RelayCommand<string>(Navigate);
        }

        public void Navigate(string section)
        {
            switch (section)
            {
                case "Sites":
                    NavigateTo(new SiteView());
                    break;
                case "Departments":
                    NavigateTo(new DepartmentView());
                    break;
                case "Employees":
                    NavigateTo(new EmployeeView());
                    break;
                default:
                    throw new ArgumentException("Invalid destination");
            }

        }
        private void NavigateTo(object destination)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainFrame.Content = destination;
        }
    }
}
