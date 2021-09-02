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
    /// Interaktionslogik für InnenkernHinzufuegenView.xaml
    /// </summary>
    public partial class InnenkernHinzufuegenView : UserControl
    {
        private string SAPNummer = "";
        private string BezeichnungRoCon = "";
        private string Aussendurchmesser = "";
        private string Toleranz_Aussendurchmesser = "";
        private string hoehe = "";
        private string Konus_Außen_Max = "";
        private string Konos_Außen_Min = "";
        private string Konos_Außen_Winkel = "";
        private string Konos_hoehe = "";
        private string Gießhoehe = "";
        private string Durchmesser_Fuehrung = "";
        private string Durchmesser_Fuherung_Toleranz = "";
        private string Durchmesser_Adapter = "";
        public InnenkernHinzufuegenView()
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

            Konus_Außen_Max = Konos_Außen_Max_TextBox.Text;
            Konos_Außen_Max_Ausgabe.Content = Konus_Außen_Max;

            Gießhoehe = Gießheohe_Max_TextBox.Text;
            Gießhoehe_Max_Ausgabe.Content = Gießhoehe;

            Durchmesser_Fuehrung = Durchmesser_Fuehrung_TextBox.Text;
            Durchmesser_Fuehrung_Ausgabe.Content = Durchmesser_Fuehrung;

            Durchmesser_Fuherung_Toleranz = Toleranz_Durchmesser_FuehrungTextBox.Text;
            Toleranz_Durchmesser_FuehrungAusgabe.Content = Durchmesser_Fuherung_Toleranz;

            Konos_Außen_Min = Konos_Außen_Min_TextBox.Text;
            Konos_Außen_Min_Ausgabe.Content = Konos_Außen_Min;

            Konos_Außen_Winkel = Konos_Außen_Max_TextBox.Text;
            Konos_Außen_Winkel_Ausgabe.Content = Konos_Außen_Winkel;

            Konos_hoehe = Konos_Hoehe_TextBox.Text;
            Konos_Hoehe_Ausgabe.Content = Konos_hoehe;

            Durchmesser_Adapter = Durchmesser_Adapter_TextBox.Text;
            Durchmesser_Adapter_Ausgabe.Content = Durchmesser_Adapter;

        



            if ((bool)Mit_Konusfuehrung.IsChecked)
            {
                KonusfuehrungAusgabe.Content = "Mit Konusführung";
            }
            else
            {
                KonusfuehrungAusgabe.Content = "Ohne Konusführung";
            }
            if ((bool)Mit_Lochführung.IsChecked)
            {
                LochfuehrungAusgabe.Content = "Mit Lochführung";
            }
            else
            {
                LochfuehrungAusgabe.Content = "Ohne Lochführung";
            }
            if ((bool)Mit_Fuehrung.IsChecked)
            {
                mitFuehrung_Ausgabe.Content = "Mit Führungsstift";
            }
            else
            {
                mitFuehrung_Ausgabe.Content = "Ohne Führungsstift";
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
                    Gießheohe_Max_TextBox.Text = "";
                    Konos_Außen_Max_TextBox.Text = "";
                    Konos_Außen_Min_TextBox.Text = "";
                    Konos_Außen_Winkel_TextBox.Text = "";
                    Konos_Hoehe_TextBox.Text = "";
                    Hoehe_Fuehrung_TextBox.Text = "";
                    Durchmesser_Fuehrung_TextBox.Text = "";
                    Toleranz_Durchmesser_FuehrungTextBox.Text = "";
                    Durchmesser_Adapter_TextBox.Text = "";

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
