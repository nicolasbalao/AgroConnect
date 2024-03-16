using Contracts.Dtos;
using Software.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Software.ViewModels
{
    internal class DepartmentViewModel: ViewModelBase
    {
        private ObservableCollection<DepartmentDto> _departments = new ObservableCollection<DepartmentDto>();
        public ObservableCollection<DepartmentDto> Departments { 
            get { return _departments; }
            set { _departments = value; OnPropertyChanged(nameof(Departments)); }
        }

        public ICommand DeleteDepartment { get; set; } 

        public  DepartmentViewModel()
        {
            LoadDepartments();
            DeleteDepartment = new RelayCommand<int>(HandleDeleteDepartment);

        }

        private async void HandleDeleteDepartment(int id)
        {
            try
            {
                await HttpService.Delete<bool>($"departments/{id}");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadDepartments();
        }

        public void LoadDepartments()
        {
            Task.Run(async () => await HttpService.Get<ObservableCollection<DepartmentDto>>("departments")).ContinueWith(t =>
            {
                Departments = t.Result;
            });
        }

        
    }
}
