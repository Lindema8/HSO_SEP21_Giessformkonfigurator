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
    /// Interaktionslogik für BausatzHinzufuegenView.xaml
    /// </summary>
    public partial class BausatzHinzufuegenView : UserControl
    {
        private string grundplatteID = "";
        private string fuehrungsringID = "";
        private string innenkernID = "";
        private string innenringID = "";

        public BausatzHinzufuegenView()
        {
            InitializeComponent();
        }

        private void Hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            grundplatteID = GrundplatteIDTextBox.Text;
            GrundplatteIDAusgabe.Content = grundplatteID;

            fuehrungsringID = FuehrungsringIDTextBox.Text;
            FuehrungsringIDAusgabe.Content = fuehrungsringID;

            innenkernID = InnenkernIDTextBox.Text;
            InnenkernIDAusgabe.Content = innenkernID;

            innenringID = InnenringIDTextBox.Text;
            InnenringIDAusgabe.Content = innenringID;


            GrundplatteIDTextBox.Text = "";
            FuehrungsringIDTextBox.Text = "";
            InnenkernIDTextBox.Text = "";
            InnenringIDTextBox.Text = "";
        }
    }
}
