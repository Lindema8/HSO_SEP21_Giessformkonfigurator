using Gießformkonfigurator.WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gießformkonfigurator.WPF.MVVM.ViewModel
{
    using Gießformkonfigurator.WPF.MVVM.Model.Db_products;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_supportClasses;
    class HinzufuegenViewModel
    {
        public string description { get; set; }

        public decimal outerDiameter { get; set; }

        public decimal innerDiameter { get; set; }

        public decimal height { get; set; }

        public int drillHoles { get; set; }

        public string material { get; set; }

        public ICommand addProductCommand { get; set; }

        public HinzufuegenViewModel()
        {
            addProductCommand = new RelayCommand(param => this.addProductToDb(), param => CanSave(4));
        }

        public void addProductToDb()
        {
            using (var db = new GießformDBContext())
            {
                ProductDisc pd = new ProductDisc() { Außendurchmesser=this.outerDiameter, Innendurchmesser=this.innerDiameter, Hoehe=this.height, Lk1Bohrungen=this.drillHoles };
                db.ProductDiscs.Add(pd);
                db.SaveChanges();
            }
        }
        private bool CanSave(int i)
        {
            return i < 5;
        }

    }
}
