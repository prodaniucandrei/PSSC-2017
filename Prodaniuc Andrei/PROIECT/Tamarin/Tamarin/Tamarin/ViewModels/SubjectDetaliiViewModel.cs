using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Tamarin.Models;
using Tamarin.Models.Enum;

namespace Tamarin.ViewModels
{
    public class SubjectDetaliiViewModel : BaseViewModel
    {
        #region detailsprops
        private string _nume;
        public string Nume
        {
            get { return _nume; }
            set { SetProperty(ref _nume, value); }
        }

        private string _locatie;
        public string Locatie
        {
            get { return _locatie; }
            set { SetProperty(ref _locatie, value); }
        }

        private bool _confirmations;
        public bool Aprobata
        {
            get { return _confirmations; }
            set { SetProperty(ref _confirmations, value); }
        }

        private string _facultate;
        public string Facultate
        {
            get { return _facultate; }
            set { SetProperty(ref _facultate, value); }
        }

        private string _serie;
        public string Serie
        {
            get { return _serie; }
            set { SetProperty(ref _serie, value); }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private string _startTime;
        public string StartTime
        {
            get { return _startTime; }
            set { SetProperty(ref _startTime, value); }
        }

        private TipActivitate _tip;
        public TipActivitate Tip
        {
            get { return _tip; }
            set { SetProperty(ref _tip, value); }
        }
        #endregion
        public SubjectDetaliiViewModel(INavigationService navigationService) : base(navigationService)
        {
            PopulateDetailsProps(Subject);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        private void PopulateDetailsProps(Materie subj)
        {
            this.Nume = subj.Nume;
            this.Tip = subj.Tip;
            this.Aprobata = subj.Aprobata;
        }

        private string GetDay(int date)
        {
            return new System.Globalization.CultureInfo("de-DE").DateTimeFormat.GetDayName((DayOfWeek)date);
        }
    }
}
