using Contracts.Dtos;
using Software.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Software.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
        }

        public void OnBeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            EmployeeDto currentItem = e.Row.Item as EmployeeDto;
            if (currentItem.IsLocked) 
            {
                e.Cancel = true;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           if(e.AddedItems.Count > 0)
            {

                EmployeeDto employee = e.AddedItems[0] as EmployeeDto;

                EmployeeViewModel vm = this.DataContext as EmployeeViewModel;

                EmployeeDetailsView employeeDetails = new EmployeeDetailsView();
                EmployeeDetailsViewModel employeeDetailsVM = new EmployeeDetailsViewModel(employee.Id);

                employeeDetails.DataContext = employeeDetailsVM;

                vm.NavigationService.NavigateTo(employeeDetails);

            } 

        }

        private void ClearSelectedSite(object sender, RoutedEventArgs e)
        {
            SiteFilter.SelectedItem = null;

        }

        private void ClearSelectedDepartment(object sender, RoutedEventArgs e)
        {
            DepartmentFilter.SelectedItem = null;

        }


        private void DeleteButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            var button = (Button)sender;
            button.Command.Execute(button.CommandParameter);
            e.Handled = true;
        }
    }
}
