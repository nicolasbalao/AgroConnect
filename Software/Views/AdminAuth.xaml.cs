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
using System.Windows.Shapes;

namespace Software.Views
{
    /// <summary>
    /// Interaction logic for AdminAuth.xaml
    /// </summary>
    public partial class AdminAuth : Window
    {
        public AdminAuth()
        {
            InitializeComponent();
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            string password = passwordBox.Password;

            AuthWindowViewModel dataContext = this.DataContext as AuthWindowViewModel;

            dataContext!.SubmitCommand.Execute(password);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            passwordBox.Focus();
        }

    }
}
