using Contracts.Dtos;
using Software.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.ViewModels
{
    internal class EmployeeViewModel: ViewModelBase
    {

        private PaginatedResponse<EmployeeDto> _paginatedEmployees = new PaginatedResponse<EmployeeDto>();

        public PaginatedResponse<EmployeeDto> PaginatedEmployees { get { return _paginatedEmployees; } 
        
        
            set { _paginatedEmployees = value; OnPropertyChanged(nameof(PaginatedEmployees)); }
        
        }


        public EmployeeViewModel() {

            LoadEmployees();
        
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

    }
}
