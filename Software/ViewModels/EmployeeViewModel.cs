using Contracts.Dtos;
using Software.Services;
using Software.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Software.ViewModels
{


    internal class EmployeeViewModel : ViewModelBase
    {

        private PaginatedResponse<EmployeeDto> _paginatedEmployees = new PaginatedResponse<EmployeeDto>();
        public PaginatedResponse<EmployeeDto> PaginatedEmployees
        {
            get { return _paginatedEmployees; }


            set { _paginatedEmployees = value; OnPropertyChanged(nameof(PaginatedEmployees)); }

        }

        private ObservableCollection<SiteDto> _sites;
        public ObservableCollection<SiteDto> Sites
        {
            get { return _sites; }

            set { _sites = value; OnPropertyChanged(nameof(Sites)); }

        }


        private DepartmentDto[] _departments;
        public DepartmentDto[] Departments
        {
            get { return _departments; }

            set { _departments = value; OnPropertyChanged(nameof(Departments)); }

        }

        public GlobalState GlobalState { get; set; } = GlobalState.Instance;

        public NavigationService NavigationService { get; }

        public ICommand CreateEmployeeCMD { get; set; }
        public ICommand DeleteEmployeeCMD { get; set; }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                LoadEmployees();
                OnPropertyChanged(nameof(SearchText));
            }

        }

        public SiteDto _siteFilterSelected;
        public SiteDto SiteFilterSelected
        {
            get { return _siteFilterSelected; }
            set { _siteFilterSelected = value; OnPropertyChanged(nameof(SiteFilterSelected)); LoadEmployees(); }
        }

        public DepartmentDto _departmentFilterSelected;
        public DepartmentDto DepartmentFilterSelected
        {
            get { return _departmentFilterSelected; }
            set { _departmentFilterSelected = value; OnPropertyChanged(nameof(DepartmentFilterSelected)); LoadEmployees(); }
        }

        private int _pageIndex = 1;
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                OnPropertyChanged(nameof(PageIndex));
                LoadEmployees();
            }
        }

        private int _totalPages;

        public int TotalPages
        {
            get { return _totalPages; }
            set { _totalPages = value; OnPropertyChanged(nameof(TotalPages)); }
        }

        public ObservableCollection<int> Sizes { get; set; } = new ObservableCollection<int>() { 5, 10, 20, 30 };

        private int _pageSize = 5;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                OnPropertyChanged(nameof(PageSize));
                LoadEmployees();
            }

        }

        public ICommand NextPage { get; set; }
        public ICommand PreviousPage { get; set; }

        public EmployeeViewModel()
        {

            NextPage = new RelayCommand<string>(HandleNextPage);
            PreviousPage = new RelayCommand<string>(HandlePreviousPage);
            NavigationService = NavigationService.Instance;
            CreateEmployeeCMD = new RelayCommand<string>(HandleCreateEmploye);
            DeleteEmployeeCMD = new RelayCommand<int>(HandleDeleteEmploye);
            LoadSites();
            LoadDepartments();
            LoadEmployees();

        }

        private async void HandleDeleteEmploye(int id)
        {

            try
            {
                await HttpService.Delete($"employees/{id}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadEmployees();

        }

        private void HandleCreateEmploye(string _)
        {

            EmployeeDetailsViewModel vm = new(null);
            EmployeeDetailsView view = new();

            view.DataContext = vm;

            NavigationService.NavigateTo(view);

        }

        private void HandleNextPage(string _)
        {
            var nextPage = PageIndex + 1;
            if (nextPage  <= _totalPages)
            {
                PageIndex++;

            }
        }

        private void HandlePreviousPage(string _)
        {

            var previousPage = PageIndex - 1;
            if (previousPage != 0)
            {
                PageIndex--;
            }
        }


        private void LoadEmployees()
        {

            Task.Run(async () =>
            {
                string query = $"?search={_searchText?.Trim()}&SiteId={_siteFilterSelected?.Id}&DepartmentId={_departmentFilterSelected?.Id}&Size={_pageSize}&Page={PageIndex}";


                if (query != String.Empty)
                {
                    return await HttpService.Get<PaginatedResponse<EmployeeDto>>($"employees{query}");

                }

                return await HttpService.Get<PaginatedResponse<EmployeeDto>>("employees");

            })
            .ContinueWith(t =>
            {

                PaginatedEmployees = t.Result;
                TotalPages = (int)Math.Ceiling((double)PaginatedEmployees.TotalItems / PaginatedEmployees.Size);

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }


        private void LoadSites()
        {

            Task.Run(async () =>
            {
                return await HttpService.Get<ObservableCollection<SiteDto>>("sites");

            })
            .ContinueWith(t =>
            {
                t.Result.Add(new SiteDto
                {
                    Id = 0,
                    City = "None"
                });

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
