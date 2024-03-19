using Contracts.Dtos;
using Software.Services;
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
    /// Interaction logic for DepartmentView.xaml
    /// </summary>
    public partial class DepartmentView : UserControl
    {
        public DepartmentView()
        {
            InitializeComponent();
        }



        private async void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            DepartmentViewModel vm = (DepartmentViewModel)DataContext;

            if (e.EditAction == DataGridEditAction.Commit)
            {
                var textBox = e.EditingElement as TextBox;
                string newValue = textBox.Text;

                DepartmentDto editedItem = (DepartmentDto)e.Row.Item; // Replace YourDataModel with your actual model

                // 0 is the default value when id doesn't exist 
                // TODO change this to null
                if (editedItem.Id != 0 && newValue != String.Empty)
                {
                    try
                    {
                        UpdateDepartmentDto updateDepartment = new UpdateDepartmentDto()
                        {
                            Id = editedItem.Id,
                            Name = newValue,
                        };

                        await HttpService.Put<SiteDto, UpdateDepartmentDto>($"departments/{editedItem.Id}", updateDepartment);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    vm.LoadDepartments();

                    return;
                }



                if (newValue != String.Empty)
                {
                    try
                    {

                        CreateDepartmentDto createdDepartment = new CreateDepartmentDto()
                        {
                            Name = newValue,
                        };

                        await HttpService.Post<SiteDto, CreateDepartmentDto>("departments", createdDepartment);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    vm.LoadDepartments();
                }

            }

        }

    }
}
