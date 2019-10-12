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
using DinoDiner.Menu;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for EntreeSelection.xaml
    /// </summary>
    public partial class EntreeSelection : Page
    {
        public EntreeSelection()
        {
            InitializeComponent();
            foreach (Entree e in MainWindow.menu.AvalibleEntrees)
            {
                Button b = new Button
                {
                    Content = e.ToString(),
                    Tag = e,
                };
                b.Click += OnButtonClicked;
                wrapPanel.Children.Add(b);
            }
        }

        public void OnButtonClicked(object sender, RoutedEventArgs args)
        {
            Console.WriteLine("Event handler");
            MainWindow.order.RaiseListChangedEvents = true;
            MainWindow.order.Add((sender as Button).Tag as IMenuItem);
            // MainWindow.order.ResetBindings();
        }
    }
}
