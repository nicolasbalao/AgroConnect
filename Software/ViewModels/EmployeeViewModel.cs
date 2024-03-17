using Contracts.Dtos;
using Software.Services;
using Software.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Software.ViewModels
{


    internal class EmployeeViewModel: ViewModelBase
    {

        private PaginatedResponse<EmployeeDto> _paginatedEmployees = new PaginatedResponse<EmployeeDto>();
        public PaginatedResponse<EmployeeDto> PaginatedEmployees { get { return _paginatedEmployees; } 
        
        
            set { _paginatedEmployees = value; OnPropertyChanged(nameof(PaginatedEmployees)); }
        
        }

        private SiteDto[] _sites;
        public SiteDto[] Sites { get { return _sites; } 
        
            set { _sites = value; OnPropertyChanged(nameof(Sites));}
        
        }


        private DepartmentDto[] _departments;
        public DepartmentDto[] Departments { get { return _departments; } 
        
            set { _departments = value; OnPropertyChanged(nameof(Departments));}
        
        }

        public GlobalState GlobalState { get; set; } = GlobalState.Instance;

        public  NavigationService NavigationService { get; }

        public ICommand CreateEmployeeCMD { get; set; }

        private string _searchText;

        public string SearchText { 
            get { return _searchText; }
            set { 
                _searchText = value; 
                LoadEmployees(); 
                OnPropertyChanged(nameof(SearchText)); 
            }
        
        }



        public EmployeeViewModel() {

            NavigationService = NavigationService.Instance;
            CreateEmployeeCMD = new RelayCommand<string>(HandleCreateEmploye);
            LoadSites();
            LoadDepartments();
            LoadEmployees();
        
        }

        private void HandleCreateEmploye(string _)
        {

            EmployeeDetailsViewModel vm = new (null);
            EmployeeDetailsView view = new ();

            view.DataContext = vm;

            NavigationService.NavigateTo(view);

        }

        


        private  void LoadEmployees()
        {

            Task.Run(async () =>
            {
                string query = String.Empty;
                if(_searchText != null)
                {
                    query = $"search={_searchText.Trim()}";
                }

               if(query != String.Empty)
                {
                    return await HttpService.Get<PaginatedResponse<EmployeeDto>>($"employees?{query}");
                }

                return await HttpService.Get<PaginatedResponse<EmployeeDto>>("employees");

            })
            .ContinueWith(t =>
            {

                PaginatedEmployees = t.Result;

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
