using System;
using Gießformkonfigurator.WPF.Core;

namespace Gießformkonfigurator.WPF.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand FormHinzufuegenViewCommand { get; set; }
        public RelayCommand HinzufuegenViewCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SuchenViewCommand { get; set; }
        public RelayCommand BauteilHinzufuegenViewCommand { get; set; }

        public FormHinzufuegenViewModel FormHinzufuegenVm { get; set; }
        public HinzufuegenViewModel HinzufuegenVm { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public SuchenViewModel SuchenVm { get; set; }
        public BauteilHinzufuegenViewModel BauteilHinzufuegenVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            SuchenVm = new SuchenViewModel();
            HinzufuegenVm = new HinzufuegenViewModel();
            FormHinzufuegenVm = new FormHinzufuegenViewModel();
            BauteilHinzufuegenVm = new BauteilHinzufuegenViewModel();

            CurrentView = SuchenVm;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVm;
            });

            SuchenViewCommand = new RelayCommand(o =>
            {
                CurrentView = SuchenVm;
            });

            HinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentView = HinzufuegenVm;
            });

            FormHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentView = FormHinzufuegenVm;
            });

            BauteilHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentView = BauteilHinzufuegenVm;
            });
        }
    }
}
