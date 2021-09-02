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
    /// Interaktionslogik für FuehrungsringHinzufuegenView.xaml
    /// </summary>
    public partial class FuehrungsringHinzufuegenView : UserControl
    {
        private string SAPNummer = "";
        private string BezeichnungRoCon = "";
        private string Aussendurchmesser = "";
        private string Toleranz_Aussendurchmesser = "";
        private string hoehe = "";
        private string Konos_hoehe = "";
        private string Gießhoehe_Max = "";
        private string Konos_Max = "";
        private string Konos_Min = "";
        private string Konos_Winkel = "";
        private string Innendurchmesser = "";
        private string Toleranz_Innendurchmesser = "";
        public FuehrungsringHinzufuegenView()
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

            Aussendurchmesser = AussendurchmesserTextBox.Text;
            AussendurchmesserAusgabe.Content = Aussendurchmesser;

            Toleranz_Aussendurchmesser = Toleranz_AussendurchmesserTextBox.Text;
            Toleranz_AußendurchmesserAusgabe.Content = Toleranz_Aussendurchmesser;

            hoehe = HoeheTextBox.Text;
            HoeheAusgabe.Content = hoehe;
            Gießhoehe_Max = Gießhoehe_Max_TextBox.Text;
            Gießhoehe_Max_Ausgabe.Content = Gießhoehe_Max;

            Konos_hoehe = Konos_Hoehe_TextBox.Text;
            Konos_Hoehe_Ausgabe.Content = Konos_hoehe;

            Konos_Max = Konos_Max_TextBox.Text;
            Konos_Max_Ausgabe.Content = Konos_Max;

            Konos_Min = Konos_Min_TextBox.Text;
            Konos_Min_Ausgabe.Content = Konos_Min;

            Konos_Winkel = Konos_Winkel_TextBox.Text;
            Konos_Winkel_Ausgabe.Content = Konos_Winkel;

            Innendurchmesser = Innendurchmesser_TextBox.Text;
            Innendurchmesser_Ausgabe.Content = Innendurchmesser;

            Toleranz_Innendurchmesser = Toleranz_Innendurchmesser_TextBox.Text;
            Toleranz_Innendurchmesser_Ausgabe.Content = Toleranz_Innendurchmesser;



            if ((bool)Mit_Konusfuehrung_Ja.IsChecked)
            {
                KonusfuehrungAusgabe.Content = "Mit Konusführung";
            }
            else
            {
                KonusfuehrungAusgabe.Content = "Ohne Konusführung";
            }
            if ((bool)ohne_Konusfuehrung_Ja.IsChecked)
            {
                ohne_Konosfuehrung_Ausgabe.Content = "Mit Konusführung";
            }
            else
            {
                ohne_Konosfuehrung_Ausgabe.Content = "Ohne Konusführung";
            }

            //Test MessageBox
            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie das Produkt hinzufügen wollen?", "Gießformkonfigurator", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Produkt hinzugefügt!", "Gießformkonfigurator");
                    SAP_Nummer_TextBox.Text = "";
                    Bezeichnung_RoConTextBox.Text = "";
                    AussendurchmesserTextBox.Text = "";
                    Toleranz_AussendurchmesserTextBox.Text = "";
                    HoeheTextBox.Text = "";
                    Innendurchmesser_TextBox.Text = "";
                    Toleranz_Innendurchmesser_TextBox.Text = "";
                    Gießhoehe_Max_TextBox.Text = "";
                    Konos_Max_TextBox.Text = "";
                    Konos_Min_TextBox.Text = "";
                    Konos_Winkel_TextBox.Text = "";
                    Konos_Hoehe_TextBox.Text = "";


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

  