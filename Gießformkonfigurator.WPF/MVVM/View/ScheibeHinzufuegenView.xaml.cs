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
    /// Interaktionslogik für ScheibeHinzufuegenView.xaml
    /// </summary>
    public partial class ScheibeHinzufuegenView : UserControl
    {
        private string parameter1 = "";
        private string parameter2 = "";
        private string slider = "";
        public ScheibeHinzufuegenView()
        {
            InitializeComponent();
        }

        private void Hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            parameter1 = Parameter1TextBox.Text;
            Parameter1Ausgabe.Content = parameter1;

            parameter2 = Parameter2TextBox.Text;
            Parameter2Ausgabe.Content = parameter2;

            slider = SliderTextBox.Text;
            int value = int.Parse(slider);
            SliderAusgabe.Content = value;

            if ((bool)Eins.IsChecked)
            {
                AuswahlAusgabe.Content = "A1";
            }
            else
            {
                AuswahlAusgabe.Content = "A2";
            }

            Parameter1TextBox.Text = "";
            Parameter2TextBox.Text = "";
            SliderTextBox.Text = "0";
        }
    }
}
