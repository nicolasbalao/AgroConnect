using Contracts.Dtos;
using Software.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.ViewModels
{
    internal class SiteViewModel : ViewModelBase
    {
        private ObservableCollection<SiteDto> _sites = new ObservableCollection<SiteDto>();
        public ObservableCollection<SiteDto> Sites { 
            get { return _sites; }
            set { _sites = value; OnPropertyChanged(nameof(Sites)); }
        }


        public  SiteViewModel()
        {
            LoadSites();

        }

        private void LoadSites()
        {
            Task.Run(async () => await HttpService.Get<ObservableCollection<SiteDto>>("sites")).ContinueWith(t =>
            {
                Sites = t.Result;
            });
        }
    }
}
