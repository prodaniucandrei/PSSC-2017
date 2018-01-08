using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tamarin.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public DelegateCommand RegisterCommand { get; set; }
        public RegisterViewModel(INavigationService navigationService) : base(navigationService)
        {
            RegisterCommand = new DelegateCommand(OnRegisterButtonExecuted);
        }

        private async void OnRegisterButtonExecuted()
        {
            
        }
    }
}
