namespace Gießformkonfigurator.WPF.MVVM.ViewModel
{
    using Gießformkonfigurator.WPF.Core;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_molds;
    using Gießformkonfigurator.WPF.MVVM.Model.Logic;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    class SuchenViewModel : ObservableObject
    {
        private ObservableCollection<ModularMold> _mGießformenFinal;
        public ObservableCollection<ModularMold> mGießformenFinal
        {
            get 
            {
                return _mGießformenFinal;
            }
        }
        public ICommand searchCommand { get; set; }
        public SuchenViewModel()
        {
            searchCommand = new SearchCommand(this);
            //findCombinations();
        }
        public void findCombinations()
        {
            CombinationJob cj = new CombinationJob(420420);
            cj.FiltereDiscDB();
            List<ModularMold> list_mGießformenFinal = cj.KombiniereMGießformen();
            this._mGießformenFinal = new ObservableCollection<ModularMold>(list_mGießformenFinal);
            //MessageBox.Show("Test");
        }
    }
}