using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tamarin.ViewModels
{
    public class StudentDetailsViewModel : BaseViewModel
    {
        private string _nume;
        private string _facultate;
        private string _an;
        private string _grupa;
        private string _subgrupa;
        private string _dateContact;
        private string _email;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Nume
        {
            get { return _nume; }
            set { SetProperty(ref _nume, value); }
        }
        public string Facultate
        {
            get { return _facultate; }
            set { SetProperty(ref _facultate, value); }
        }
        public string An
        {
            get { return _an; }
            set { SetProperty(ref _an, value); }
        }
        public string Grupa
        {
            get { return _grupa; }
            set { SetProperty(ref _grupa, value); }
        }
        public string Subgrupa
        {
            get { return _subgrupa; }
            set { SetProperty(ref _subgrupa, value); }
        }
        public string DateContact
        {
            get { return _dateContact; }
            set { SetProperty(ref _dateContact, value); }
        }
        public DelegateCommand SubmitCommand { get; set; }

        public StudentDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            SubmitCommand = new DelegateCommand(OnSubmitData);
        }

        private async void OnSubmitData()
        {
            //submit data
        }
    }
}
