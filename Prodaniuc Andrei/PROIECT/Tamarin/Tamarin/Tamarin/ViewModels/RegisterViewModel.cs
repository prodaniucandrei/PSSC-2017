using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Tamarin.Models;
using Tamarin.Services;

namespace Tamarin.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private double _elementsOpacity;
        private string _email;
        private string _password;
        private string _retypePassword;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public string RetypePassword
        {
            get { return _retypePassword; }
            set { SetProperty(ref _retypePassword, value); }
        }

        public double ElementsOpacity
        {
            get { return _elementsOpacity; }
            set
            {
                SetProperty(ref _elementsOpacity, value);
            }
        }

        public DelegateCommand RegisterCommand { get; set; }
        public RegisterViewModel(INavigationService navigationService) : base(navigationService)
        {
            RegisterCommand = new DelegateCommand(OnRegisterButtonExecuted);
            ElementsOpacity = 1;
        }

        private async void OnRegisterButtonExecuted()
        {
            IsBusy = true;
            ElementsOpacity = .2;
            if (!Password.Equals(RetypePassword)) { }
            //await DisplayAlert("Error", "Username or password is not corect", "OK");
            else
            {
                var userModel = new LoginModel() { Email = Email, Password = Password };
                var response = await AuthService.Register(userModel);

                if (response.IsSuccessStatusCode)
                {
                    IsBusy = false;
                    ElementsOpacity = 1;
                    await _navigationService.NavigateAsync("Login");
                }
            }
        }
    }
}
