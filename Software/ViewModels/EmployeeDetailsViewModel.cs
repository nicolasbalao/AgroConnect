using Contracts.Dtos;
using Software.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

// TODO: Refactor this ugly thing
namespace Software.ViewModels
{
    internal class EmployeeDetailsViewModel : ViewModelBase
    {

        public NavigationService NavigationService { get; set; }
        public GlobalState GlobalStateService { get; set; }

        public ICommand ToggleEdition { get; set; }
        public ICommand OnSave { get; set; }


        private EmployeeDto _employee = new() {};
        public EmployeeDto Employee { get { return _employee; } set {

                _employee = value;
                OnPropertyChanged(nameof(Employee));

            } }


        private SiteDto[] _sites;
        public SiteDto[] Sites { get { return _sites; } set {

                _sites = value;
                OnPropertyChanged(nameof(Sites));
            } }

        private DepartmentDto[] _departments;

        public DepartmentDto[] Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                OnPropertyChanged(nameof(Departments));

            }
        }


        private bool  _isEditing = false;

        public bool  IsEditing
        {
            get { return _isEditing; }
            set { _isEditing = value == true; OnPropertyChanged(nameof(IsEditing)); }
        }


        private int _siteSelectedId;
        public int SiteSelectedId { get { return _siteSelectedId; } set
            {
                _siteSelectedId = value;
                OnPropertyChanged(nameof(SiteSelectedId));
            } }





        public EmployeeDetailsViewModel(int? id)
        {
            ToggleEdition = new RelayCommand<string>(HandleToggleEdition);
            OnSave = new RelayCommand<string>(HandlingOnSave);
            GlobalStateService = GlobalState.Instance;
            NavigationService = NavigationService.Instance;
            if(id != null)
            {
                LoadEmployee((int)id);
            }
            else
            {
                IsEditing = true;
            }

            LoadDepartments();
            LoadSites();
        }

        private async void HandleToggleEdition(string _) {

            try
            {
                if (!Employee.IsLocked)
                {
                    throw new Exception("Locked");
                }
                else
                {
                    await HttpService.LockEmployee(Employee.Id);
                }

            }catch (Exception ex) { 
                MessageBox.Show(ex.Message);
                return;

            }
            
            IsEditing = !IsEditing;
        }

        private async void HandlingOnSave(string _)
        {
            if (Employee.Id != 0)
            {

                UpdateEmployeeDto data = new UpdateEmployeeDto()
                {
                    Id=Employee.Id,
                    Firstname = Employee.Firstname,
                    Lastname = Employee.Lastname,
                    Email = Employee.Email,
                    HomePhone = Employee.HomePhone,
                    CellPhone   = Employee.CellPhone,
                    SiteId = Employee.Site.Id,
                    DepartmentId = Employee.Department.Id,
                    
                };

                try
                {

                    var updatedEmploye = await HttpService.Put<EmployeeDto, UpdateEmployeeDto>($"employees/{Employee.Id}", data);
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            NavigationService.Navigate("Employees");
                return;
            }

            CreateEmployeeDto createEmployeeDto = new CreateEmployeeDto()
            {
                Firstname = Employee.Firstname,
                Lastname = Employee.Lastname,
                Email = Employee.Email,
                HomePhone = Employee.HomePhone,
                CellPhone = Employee.CellPhone,
                SiteId = Employee.Site.Id,
                DepartmentId = Employee.Department.Id,
            };

            try
            {
                await HttpService.Post<EmployeeDto, CreateEmployeeDto>("employees", createEmployeeDto);

            }
            catch (Exception e){

                MessageBox.Show(e.Message);
            
            }



            NavigationService.Navigate("Employees");


        }




        private void LoadEmployee(int id)
        {

            Task.Run(async () =>
            {
                return await HttpService.Get<EmployeeDto>($"employees/{id}");

            }).ContinueWith(t =>
            {
                // For the UI
                // TODO make boolean negative Converter
                t.Result.IsLocked = !t.Result.IsLocked;
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
