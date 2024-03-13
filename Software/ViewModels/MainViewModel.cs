using System.Windows;
using System.Windows.Input;
using Contracts.Dtos;
using Newtonsoft.Json.Converters;
using Software.Services;
using Software.Views;

namespace Software.ViewModels
{
    internal class MainViewModel : ViewModelBase 
    {

        public ICommand NavigateCommand { get; }
        public ICommand ShowAuthWindow { get; }

        private bool _isAdmin;

        private GlobalState _globalState;

        public bool IsAdmin { get { return _isAdmin; }
        
            set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); }
        
        }


        public  MainViewModel(GlobalState globalState)
        {
            NavigateCommand = new RelayCommand<string>(Navigate);
            ShowAuthWindow = new RelayCommand<string>(ShowAdminAuthWindow);
            _globalState = globalState;

            _globalState.IsAdminChanged += GlobalStateService_IsAdminChanged ;

        }

        private void GlobalStateService_IsAdminChanged(object sender, EventArgs e)
        {
            IsAdmin = _globalState.IsAdmin;
                   
        }

        public void ShowAdminAuthWindow(string arg)
        {
            // Create an instance of the popup window
            AuthWindowViewModel authViewModel = new AuthWindowViewModel(_globalState);
            Window adminAuth = new AdminAuth();

            authViewModel.CloseAction = () => adminAuth.Close();


            adminAuth.DataContext = authViewModel;
            adminAuth.ShowDialog();


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
