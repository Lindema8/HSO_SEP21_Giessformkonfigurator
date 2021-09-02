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
    /// Interaktionslogik für GrundplatteHinzufuegenView.xaml
    /// </summary>
    public partial class GrundplatteHinzufuegenView : UserControl
    {
        private string SAPNummer = "";
        private string BezeichnungRoCon = "";
        private string hoehe = "";
        private string Aussendurchmesser = "";
        private string Konos_Außen_Max = "";
        private string Konos_Außen_Min = "";
        private string Konos_Außen_Winkel = "";
        private string Konos_hoehe = "";
        private string Konos_Innen_Max = "";
        private string Konos_Innen_Min = "";
        private string Konos_Innen_Winkel = "";
        private string Innendurchmesser = "";
        private string Toleranz_Innendurchmesser = "";
        public GrundplatteHinzufuegenView()
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

            hoehe = HoeheTextBox.Text;
            HoeheAusgabe.Content = hoehe;

            Konos_Außen_Max = Konos_Außen_Max_TextBox.Text;
            Konos_Außen_Max_Ausgabe.Content = Konos_Außen_Max;

            Konos_Außen_Min = Konos_Außen_Min_TextBox.Text;
            Konos_Außen_Min_Ausgabe.Content = Konos_Außen_Min;

            Konos_Außen_Winkel = Konos_Außen_Max_TextBox.Text;
            Konos_Außen_Winkel_Ausgabe.Content = Konos_Außen_Winkel;

            Konos_hoehe = Konos_Hoehe_TextBox.Text;
            Konos_Hoehe_Ausgabe.Content = Konos_hoehe;

            Konos_Innen_Max = Konos_Innen_Max_TextBox.Text;
            Konos_Innen_Max_Ausgabe.Content = Konos_Innen_Max;

            Konos_Innen_Min = Konos_Innen_Min_TextBox.Text;
            Konos_Innen_Min_Ausgabe.Content = Konos_Innen_Min;

            Konos_Innen_Winkel = Konos_Innen_Winkel_TextBox.Text;
            Konos_Innen_Winkel_Ausgabe.Content = Konos_Innen_Winkel;

            Innendurchmesser = Innendurchmesser_TextBox.Text;
            Innendurchmesser_Ausgabe.Content = Innendurchmesser;

            Toleranz_Innendurchmesser = Toleranz_Innendurchmesser_TextBox.Text;
            Toleranz_Innendurchmesser_Ausgabe.Content = Toleranz_Innendurchmesser;



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
            if ((bool)Mit_Kern.IsChecked)
            {
                mitKern_Ausgabe.Content = "Mit Kern";
            }
            else
            {
                mitKern_Ausgabe.Content = "Ohne Kern";
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
                    AussendurchmesserTextBox.Text = "";
                    Konos_Außen_Max_TextBox.Text = "";
                    Konos_Außen_Min_TextBox.Text = "";
                    Konos_Außen_Winkel_TextBox.Text = "";
                    Konos_Hoehe_TextBox.Text = "";
                    Konos_Innen_Max_TextBox.Text = "";
                    Konos_Innen_Min_TextBox.Text = "";
                    Konos_Innen_Winkel_TextBox.Text = "";
                    Innendurchmesser_TextBox.Text= "";
                    Toleranz_Innendurchmesser_TextBox.Text = "";


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

