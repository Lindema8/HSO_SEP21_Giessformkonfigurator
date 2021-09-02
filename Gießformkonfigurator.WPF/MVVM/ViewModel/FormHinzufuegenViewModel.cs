using System;
using Gießformkonfigurator.WPF.Core;

namespace Gießformkonfigurator.WPF.MVVM.ViewModel
{
    class FormHinzufuegenViewModel : ObservableObject
    {
        public RelayCommand ScheibeHinzufuegenViewCommand { get; set; }
        public RelayCommand CupHinzufuegenViewCommand { get; set; }
        public RelayCommand BausatzHinzufuegenViewCommand { get; set; }

        public ScheibeHinzufuegenViewModel ScheibeHinzufuegenVm { get; set; }
        public CupHinzufuegenViewModel CupHinzufuegenVm { get; set; }
        public BausatzHinzufuegenViewModel BausatzHinzufuegenVm { get; set; }

        private object _currentViewFormHinzufuegen;
        public object CurrentViewFormHinzufuegen
        {
            get { return _currentViewFormHinzufuegen; }
            set
            {
                _currentViewFormHinzufuegen = value;
                OnPropertyChanged();
            }
        }

        public FormHinzufuegenViewModel()
        {
            ScheibeHinzufuegenVm = new ScheibeHinzufuegenViewModel();
            CupHinzufuegenVm = new CupHinzufuegenViewModel();
            BausatzHinzufuegenVm = new BausatzHinzufuegenViewModel();

            CurrentViewFormHinzufuegen = ScheibeHinzufuegenVm;

            ScheibeHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentViewFormHinzufuegen = ScheibeHinzufuegenVm;
            });

            CupHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentViewFormHinzufuegen = CupHinzufuegenVm;
            });

            BausatzHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentViewFormHinzufuegen = BausatzHinzufuegenVm;
            });
        }
    }
}
