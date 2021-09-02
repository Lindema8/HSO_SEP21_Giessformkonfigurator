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
    /// Interaktionslogik für AnsichtZwei.xaml
    /// </summary>
    public partial class AnsichtZwei : UserControl
    {
        private string produktID = "";

        //Ausgabe-Variablen
        Label[] test = new Label[12];
        Label[] test2 = new Label[12];
        int location = 10;
        public AnsichtZwei()
        {
            InitializeComponent();
        }

        private void ProduktID_Click(object sender, RoutedEventArgs e)
        {
            //Read Value
            produktID = ProduktIDTextBox.Text;
            EingabeAusgabe.Content = "Das Produkt mit der ProduktID : '" + produktID + "' kann mit folgenden Gießformen angefertigt werden.";

            //Clear TextBox
            ProduktIDTextBox.Text = "";

            //Ausgabe-Labels erstellen
            for (int i = 0; i < test.Length; i++)
            {
                Label test = new Label();
                test.Height = 50;
                test.Width = 800;
                test.FontSize = 15;
                test.Foreground = Brushes.Black;
                test.HorizontalAlignment = HorizontalAlignment.Left;
                test.Content = i+1 + ". Test";
                test.Margin = new Thickness(10, location, 0, 0);
                SuchenAusgabe.Children.Add(test);
            }

            for (int i = 0; i < test2.Length; i++)
            {
                Label test = new Label();
                test.Height = 50;
                test.Width = 800;
                test.FontSize = 15;
                test.Foreground = Brushes.Black;
                test.HorizontalAlignment = HorizontalAlignment.Left;
                test.Content = "Test"+ i + 1;
                test.Margin = new Thickness(10, location, 0, 0);
                SuchenAusgabe2.Children.Add(test);
            }
        }
    }
}
