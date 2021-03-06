﻿using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Tamarin.Models;
using Tamarin.Services;
using Xamarin.Forms;

namespace Tamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private double _elementsOpacity;
        private string _errorMessage;
        private string _username = "";
        private string _password ="";

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public double ElementsOpacity
        {
            get { return _elementsOpacity; }
            set
            {
                SetProperty(ref _elementsOpacity, value);
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                SetProperty(ref _errorMessage, value);
            }
        }

        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }

        public LoginViewModel(INavigationService navigationService): base(navigationService)
        {
            LoginCommand = new DelegateCommand(OnLoginCommandExecuted);
            RegisterCommand = new DelegateCommand(OnRegisterButtonPressed);
            ElementsOpacity = 1;
        }

        private async void OnRegisterButtonPressed()
        {
            await _navigationService.NavigateAsync("Register");
        }

        public async void OnLoginCommandExecuted()
        {
            IsBusy = true;
            ElementsOpacity = .2;

            var model = new LoginModel();
            model.Email = Username;
            model.Password = Password;
            try
            {
                var response = await AuthService.Login(model);

                if (response.IsSuccessStatusCode)
                {
                    IsBusy = false;
                    ElementsOpacity = 1;

                    var content = await response.Content.ReadAsStringAsync();
                    var message = JsonConvert.DeserializeObject<UserLogged>(content);
                    Application.Current.Properties["id"] = message.Id;
                    Application.Current.Properties["email"] = Username;
                    Application.Current.Properties["isLoggedIn"] = message.IsSetUp;

                    await _navigationService.NavigateAsync("/Home/Navigation/Dashboard?message=Welcome");
                }
                else
                {
                    IsBusy = false;
                    ElementsOpacity = 1;

                    //await DisplayAlert("Error", "Username or password is not corect", "OK");
                }
            }
            catch (Exception x)
            {

            }
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
