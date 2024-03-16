using Software.ViewModels;
using Software.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Software.Services
{
    internal class NavigationService
    {


        public ICommand NavigateCommand { get; }


        private static readonly NavigationService _instance = new NavigationService();
        public static NavigationService Instance
        {
            get { return _instance; }
        }

        private NavigationService() {
            NavigateCommand = new RelayCommand<string>(Navigate);
        }  

        public void Navigate(string section)
        {
            switch (section)
            {
                case "Sites":
                    SiteView view = new SiteView();
                    NavigateTo(view);
                    break;
                case "Departments":
                    NavigateTo(new DepartmentView());
                    break;
                case "Employees":
                    EmployeeView employeeView = new EmployeeView();
                    employeeView.DataContext = new EmployeeViewModel();
                    NavigateTo(employeeView);
                    break;
                case "EmployeeDetails":

                default:
                    throw new ArgumentException("Invalid destination");
            }

        }

        public void NavigateTo(object destination)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainFrame.Content = destination;
        }

    }
}
