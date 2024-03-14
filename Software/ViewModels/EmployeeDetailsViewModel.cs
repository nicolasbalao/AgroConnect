using Contracts.Dtos;
using Software.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Software.ViewModels
{
    internal class EmployeeDetailsViewModel : ViewModelBase
    {

        public GlobalState GlobalStateService { get; set; }

        public ICommand ToggleEdition { get; set; }

        
        public EmployeeDto Employee { get; set; }
        public SiteDto[] Sites { get; set; }
        public DepartmentDto[] Departments { get; set; }


        private bool  _isEditing = false;

        public bool  IsEditing
        {
            get { return _isEditing; }
            set { _isEditing = value == true; OnPropertyChanged(nameof(IsEditing)); }
        }



        public EmployeeDetailsViewModel(int id)
        {
            ToggleEdition = new RelayCommand<string>(HandleToggleEdition);
            GlobalStateService = GlobalState.Instance;
            LoadEmployee(id);
            LoadDepartments();
            LoadSites();
        }

        private void HandleToggleEdition(string _) {
        
            IsEditing = !IsEditing;
        }


        private void LoadEmployee(int id)
        {

            Task.Run(async () =>
            {
                return await HttpService.Get<EmployeeDto>($"employees/{id}");

            }).ContinueWith(t =>
            {
                Employee = t.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadSites()
        {

            Task.Run(async () =>
            {
                return await HttpService.Get<SiteDto[]>("sites");

            })
            .ContinueWith(t =>
            {

                Sites = t.Result;

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }


        private void LoadDepartments()
        {

            Task.Run(async () =>
            {
                return await HttpService.Get<DepartmentDto[]>("departments");

            })
            .ContinueWith(t =>
            {

                Departments = t.Result;

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }


    }
}
