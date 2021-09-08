using Gießformkonfigurator.WPF.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gießformkonfigurator.WPF.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für HinzufuegenView.xaml
    /// </summary>
    public partial class HinzufuegenView : UserControl
    {
        private string aussendurchmesser = "";
        private string innendurchmesser = "";
        private string hoehe = "";
        private string freierParameter = "";
        private string bohrungen = "";
        public HinzufuegenView()
        {
            InitializeComponent();
            this.DataContext = new HinzufuegenViewModel();
        }

        private void Hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            //Read Values
            aussendurchmesser = AussendurchmesserTextBox.Text;

            innendurchmesser = InnendurchmesserTextBox.Text;

            hoehe = HoeheTextBox.Text;

            freierParameter = descriptionTextBox.Text;

            bohrungen = BohrungenTextBox.Text;
            int value = int.Parse(bohrungen);

            //Test MessageBox
            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie das Produkt hinzufügen wollen?", "Gießformkonfigurator", MessageBoxButton.YesNo);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Produkt hinzugefügt!", "Gießformkonfigurator");
                    AussendurchmesserTextBox.Text = "";
                    InnendurchmesserTextBox.Text = "";
                    HoeheTextBox.Text = "";
                    descriptionTextBox.Text = "";
                    BohrungenTextBox.Text = "0";
                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("Produkt verworfen", "My App");
                    break;
            }

            //Clear TextBoxes
            /**AussendurchmesserTextBox.Text = "";
            InnendurchmesserTextBox.Text = "";
            HoeheTextBox.Text = "";
            FreierParameterTextBox.Text = "";
            BohrungenTextBox.Text = "0";*/

        }
    }
}
