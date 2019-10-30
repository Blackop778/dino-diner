/* ComboSelection.xaml.cs
 * Author: Nathan Faltermeier
 */
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
    /// Interaction logic for ComboSelection.xaml
    /// </summary>
    public partial class ComboSelection : Page
    {
        public ComboSelection()
        {
            InitializeComponent();
            foreach (CretaceousCombo c in MainWindow.menu.AvailableCombos)
            {
                Button b = new Button
                {
                    Content = c.ToString(),
                    Tag = c
                };
                b.Click += OnButtonClicked;
                wrapPanel.Children.Add(b);
            }
        }

        /// <summary>
        /// Adds the chosen combo to the order
        /// </summary>
        public void OnButtonClicked(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                CretaceousCombo c = ((sender as Button).Tag as IOrderItem).Clone() as CretaceousCombo;
                order.Items.Add(c);
                CollectionViewSource.GetDefaultView(order.Items).MoveCurrentToLast();
                NavigationService.Navigate(new CustomizeCombo());
            }
        }
    }
}
