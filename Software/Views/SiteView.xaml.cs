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
    /// Interaction logic for Site.xaml
    /// </summary>
    public partial class SiteView : UserControl
    {
        public SiteView()
        {
            InitializeComponent();
        }

        private async void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            SiteViewModel vm = (SiteViewModel)DataContext;

            if (e.EditAction == DataGridEditAction.Commit)
            {
                var textBox = e.EditingElement as TextBox;
                string newValue = textBox.Text; 

                SiteDto editedItem = (SiteDto)e.Row.Item; // Replace YourDataModel with your actual model

                // 0 is the default value when id doesn't exist 
                // TODO change this to null
                if(editedItem.Id != 0)
                {
                    try
                    {
                        UpdateSiteDto updateSite = new UpdateSiteDto()
                        {
                            Id = editedItem.Id,
                            City = newValue,
                        };

                        await HttpService.Put<SiteDto, UpdateSiteDto>($"sites/{editedItem.Id}", updateSite);

                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    vm.LoadSites();

                    return;
                }



                try
                {

                    CreateSiteDto createdSite = new CreateSiteDto()
                    {
                        City = newValue,
                    };

                    await HttpService.Post<SiteDto, CreateSiteDto>("sites", createdSite);

                }catch(Exception ex)
                {
                    MessageBox.Show (ex.Message);   
                }
                vm.LoadSites();

            }

        }
    }
}
