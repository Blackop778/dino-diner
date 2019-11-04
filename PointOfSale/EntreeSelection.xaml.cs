/* EntreeSelection.xaml.cs
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

        /// <summary>
        /// Adds the chosen entree to the order
        /// </summary>
        public void OnButtonClicked(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                order.Items.Add(((sender as Button).Tag as IOrderItem).Clone() as IOrderItem);
                CollectionViewSource.GetDefaultView(order.Items).MoveCurrentToLast();
            }

            Page customizationPage = GetCustomizationPage((sender as Button).Tag as Entree);
            if (customizationPage != null)
            {
                NavigationService.Navigate(customizationPage);
            }
            else if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        internal static Page GetCustomizationPage(Entree e)
        {
            if (e is Brontowurst)
                return new CustomizeBrontowurst();
            else if (e is DinoNuggets)
                return new CustomizeDinoNuggets();
            else if (e is PrehistoricPBJ)
                return new CustomizePrehistoricPBJ();
            else if (e is SteakosaurusBurger)
                return new CustomizeSteakosaurusBurger();
            else if (e is TRexKingBurger)
                return new CustomizeTRexKingBurger();
            else if (e is VelociWrap)
                return new CustomizeVelociWrap();
            else
                return null;
        }

        /// <summary>
        /// Gets the entree (in a combo or not) the user has selected in the order, or null if one is not found
        /// </summary>
        /// <returns>the entree (in a combo or not) the user has selected in the order, or null if one is not found</returns>
        internal static Entree GetCurrentEntree(FrameworkElement e)
        {
            if (e.DataContext is Order order)
            {
                if (CollectionViewSource.GetDefaultView(order.Items).CurrentItem is CretaceousCombo c)
                    return c.Entree;
                return CollectionViewSource.GetDefaultView(order.Items).CurrentItem as Entree;
            }

            return null;
        }
    }
}
