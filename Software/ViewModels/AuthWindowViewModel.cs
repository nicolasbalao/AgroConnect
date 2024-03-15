using Contracts.Dtos;
using Software.Services;
using Software.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Software.ViewModels
{
    internal class AuthWindowViewModel : ViewModelBase
    {

        public ICommand SubmitCommand {  get;  }
        public Action CloseAction { get; set; }

        private GlobalState GlobalState { get; set; }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public AuthWindowViewModel(GlobalState globalState)
        {
            SubmitCommand = new RelayCommand<string>(OnSubmit);
            GlobalState = globalState;
        }



        private async void OnSubmit(string password)
        {

            LoginRequest loginRequest = new LoginRequest()
            {
                Password = password,
            };

            var success = await HttpService.Login(loginRequest);

            if (!success)
            {

                MessageBox.Show("Invalide password");
                return;
            }
            GlobalState.IsAdmin = true;
            CloseAction?.Invoke();
            return;
        }

    }

}
