namespace Gießformkonfigurator.WPF.MVVM.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Gießformkonfigurator.WPF.MVVM.ViewModel;

    /// <summary>
    /// Interaktionslogik für AnsichtZwei.xaml
    /// </summary>
    public partial class AnsichtZwei : UserControl
    {
        private SuchenViewModel ViewModel { get; set; }

        public AnsichtZwei()
        {
            InitializeComponent();
            this.DataContext = new SuchenViewModel();
        }

        /*private void ProduktID_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.findCombinations();
            combinationJobOutput.CommitEdit();
        }*/
    }
}
