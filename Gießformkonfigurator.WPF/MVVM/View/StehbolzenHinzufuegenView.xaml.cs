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
    /// Interaktionslogik für StehbolzenHinzufuegenView.xaml
    /// </summary>
    public partial class StehbolzenHinzufuegenView : UserControl
    {
        private string SAPNummer = "";
        private string BezeichnungRoCon = "";
        private string hoehe = "";
        private string Außendurchmesser = "";
        private string Gießhoehe_Max = "";
        private string Gewinde = "";
        private string Hoehe_fuehrung = "";
        private string Außendurchmesser_fuehrung = "";
        public StehbolzenHinzufuegenView()
        {
            InitializeComponent();
        }
        private void Hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            //Read Values
            SAPNummer = SAP_Nummer_TextBox.Text;
            SAP_Nummer_Ausgabe.Content = SAPNummer;

            BezeichnungRoCon = Bezeichnung_RoConTextBox.Text;
            Bezeichnung_RoConAusgabe.Content = BezeichnungRoCon;

            hoehe = HoeheTextBox.Text;
            HoeheAusgabe.Content = hoehe;

            Außendurchmesser = Außendurchmesser_Textbox.Text;
            Außendurchmesser_Ausgabe.Content = Außendurchmesser;

            Gießhoehe_Max = Gießhoehemax_TextBox.Text;
            Gießhoehe_Max_Ausgabe.Content = Gießhoehe_Max;

            Gewinde = Gewinde_TextBox.Text;
            Gewinde_Ausgabe.Content = Gewinde;

            Hoehe_fuehrung = Hoehe_Fuehrung_TextBox.Text;
            Hoehe_Fuehrung_Ausgabe.Content = Hoehe_fuehrung;

            Außendurchmesser_fuehrung = Außendurchmesser_Fuehrung_TextBox.Text;
            Außendurchmesser_Fuehrung_Ausgabe.Content = Außendurchmesser_fuehrung;



            if ((bool)Mit_Gewinde.IsChecked)
            {
                GewindeAusgabe.Content = "Mit Gewinde";
            }
            else
            {
                GewindeAusgabe.Content = "Ohne Gewinde";
            }
            if ((bool)Mit_Steckbolzen.IsChecked)
            {
                SteckbolzenAusgabe.Content = "Mit Steckbolzen";
            }
            else
            {
                SteckbolzenAusgabe.Content = "Ohne Steckbolzen";
            }
          

            //Test MessageBox
            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie das Produkt hinzufügen wollen?", "Gießformkonfigurator", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Produkt hinzugefügt!", "Gießformkonfigurator");
                    SAP_Nummer_TextBox.Text = "";
                    Bezeichnung_RoConTextBox.Text = "";
                    HoeheTextBox.Text = "";
                    Außendurchmesser_Textbox.Text = "";
                    Gießhoehemax_TextBox.Text = "";
                    Gewinde_TextBox.Text = "";
                    Hoehe_Fuehrung_TextBox.Text = "";
                    Außendurchmesser_Fuehrung_TextBox.Text = "";




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
