using Contracts.Dtos;
using Software.Services;
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

        public GlobalState GlobalState { get; set; }
        public  NavigationService NavigationService { get; }


        public EmployeeViewModel() {

            NavigationService = NavigationService.Instance;
            LoadSites();
            LoadDepartments();
            LoadEmployees();
            GlobalState = GlobalState.Instance;
        
        }

        


        private  void LoadEmployees()
        {

            Task.Run(async () =>
            {
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
