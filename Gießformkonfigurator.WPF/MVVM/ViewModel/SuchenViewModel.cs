namespace Gießformkonfigurator.WPF.MVVM.ViewModel
{
    using Gießformkonfigurator.WPF.Core;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_molds;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_products;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_supportClasses;
    using Gießformkonfigurator.WPF.MVVM.Model.Logic;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    class SuchenViewModel : ObservableObject
    {
        public ObservableCollection<ModularMold> mGießformenFinal { get; } = new ObservableCollection<ModularMold>();

        private ProgramLogic programLogic { get; set; }

        public string listSize { get; set; }

        public int productId { get; set; }

        public ICommand searchCommand { get; set; }

        public SuchenViewModel()
        {
            searchCommand = new RelayCommand(param => findMatchingMolds(), param => validateSearch());
        }

        public void findMatchingMolds()
        {
            Product product;

            using (var db = new GießformDBContext())
            {
                product = db.ProductDiscs.Find(productId);
            }

            if (product != null)
            {
                programLogic = new ProgramLogic(product);

                this.mGießformenFinal.Clear();

                foreach (var mold in programLogic.combinationJob.CombineMoldComponents())
                {
                    this.mGießformenFinal.Add(mold);
                }

                this.listSize = this.mGießformenFinal.Count.ToString();
            }
            else
                MessageBox.Show("Es stimmt kein Produkt mit der eingegebenen SAP-Nr. überein. Bitte validiere die Eingabe!");
        }

        public bool validateSearch()
        {
            if (productId != 0)
                return true;
            else
                return false;
        }
    }
}