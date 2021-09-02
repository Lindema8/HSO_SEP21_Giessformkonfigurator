namespace Gießformkonfigurator.WPF.MVVM.View
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using Gießformkonfigurator.WPF.MVVM.ViewModel;

    /// <summary>
    /// Interaktionslogik für AnsichtZwei.xaml
    /// </summary>
    public partial class AnsichtZwei : UserControl
    {
        private SuchenViewModel swm;

        public AnsichtZwei()
        {
            InitializeComponent();
            //DataContext = new SuchenViewModel();
            swm = new SuchenViewModel();
        }

        public void populateGrid(object sender, RoutedEventArgs e)
        {
            swm.findCombinations();
            combinationJobOutput.Items.Refresh();
        }
    }
}
