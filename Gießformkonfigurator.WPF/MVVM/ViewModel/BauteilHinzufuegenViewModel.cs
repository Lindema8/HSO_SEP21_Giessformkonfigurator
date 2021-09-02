using System;
using Gießformkonfigurator.WPF.Core;

namespace Gießformkonfigurator.WPF.MVVM.ViewModel
{
    class BauteilHinzufuegenViewModel : ObservableObject
    {
        public RelayCommand GrundplatteHinzufuegenViewCommand { get; set; }
        public RelayCommand EinlegeplatteHinzufuegenViewCommand { get; set; }
        public RelayCommand StehbolzenHinzufuegenViewCommand { get; set; }
        public RelayCommand FuehrungsringHinzufuegenViewCommand { get; set; }
        public RelayCommand InnenringHinzufuegenViewCommand { get; set; }
        public RelayCommand InnenkernHinzufuegenViewCommand { get; set; }
        public RelayCommand KernringHinzufuegenViewCommand { get; set; }

        public GrundplatteHinzufuegenViewModel GrundplatteHinzufuegenVm { get; set; }
        public EinlegeplatteHinzufuegenViewModel EinlegeplatteHinzufuegenVm { get; set; }
        public StehbolzenHinzufuegenViewModel StehbolzenHinzufuegenVm { get; set; }
        public FuehrungsringHinzufuegenViewModel FuehrungsringHinzufuegenVm { get; set; }
        public InnenringHinzufuegenViewModel InnenringHinzufuegenVm { get; set; }
        public InnenkernHinzufuegenViewModel InnenkernHinzufuegenVm { get; set; }
        public KernringHinzufuegenViewModel KernringHinzufuegenVm { get; set; }

        private object _currentViewBauteilHinzufuegen;

        public object CurrentViewBauteilHinzufuegen
        {
            get { return _currentViewBauteilHinzufuegen; }
            set
            {
                _currentViewBauteilHinzufuegen = value;
                OnPropertyChanged();
            }
        }

        public BauteilHinzufuegenViewModel()
        {
            GrundplatteHinzufuegenVm = new GrundplatteHinzufuegenViewModel();
            EinlegeplatteHinzufuegenVm = new EinlegeplatteHinzufuegenViewModel();
            StehbolzenHinzufuegenVm = new StehbolzenHinzufuegenViewModel();
            FuehrungsringHinzufuegenVm = new FuehrungsringHinzufuegenViewModel();
            InnenringHinzufuegenVm = new InnenringHinzufuegenViewModel();
            InnenkernHinzufuegenVm = new InnenkernHinzufuegenViewModel();
            KernringHinzufuegenVm = new KernringHinzufuegenViewModel();

            CurrentViewBauteilHinzufuegen = GrundplatteHinzufuegenVm;

            GrundplatteHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentViewBauteilHinzufuegen = GrundplatteHinzufuegenVm;
            });

            EinlegeplatteHinzufuegenViewCommand = new RelayCommand(o => 
            {
                CurrentViewBauteilHinzufuegen = EinlegeplatteHinzufuegenVm;
            });

            StehbolzenHinzufuegenViewCommand = new RelayCommand(o => 
            {
                CurrentViewBauteilHinzufuegen = StehbolzenHinzufuegenVm;
            });

            FuehrungsringHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentViewBauteilHinzufuegen = FuehrungsringHinzufuegenVm;
            });

            InnenringHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentViewBauteilHinzufuegen = InnenringHinzufuegenVm;
            });

            InnenkernHinzufuegenViewCommand = new RelayCommand(o =>
            {
                CurrentViewBauteilHinzufuegen = InnenkernHinzufuegenVm;
            });

            KernringHinzufuegenViewCommand = new RelayCommand(o => 
            {
                CurrentViewBauteilHinzufuegen = KernringHinzufuegenVm;
            });
        }
    }
}
