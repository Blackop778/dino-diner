/* CustomizeCombo.xaml.cs
 * Author: Nathan Faltermeier
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CustomizeCombo.xaml. Note there is a bunch of logic for updating the side and drink buttons in MainWindow.xaml.cs as well.
    /// </summary>
    public partial class CustomizeCombo : Page
    {
        /// <summary>
        /// Creates a combo customization page
        /// </summary>
        public CustomizeCombo()
        {
            InitializeComponent();
            smallButton.Tag = DinoDiner.Menu.Size.Small;
            mediumButton.Tag = DinoDiner.Menu.Size.Medium;
            largeButton.Tag = DinoDiner.Menu.Size.Large;
            // The constructor is called before the DataContext is set so we can't get the currently selected combo yet
            DataContextChanged += CustomizeCombo_DataContextChanged;
        }

        /// <summary>
        /// Once the DataContext is set update the current side and drink buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomizeCombo_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateButtonLabels(null, null);
            // Don't add UpdateButtonLabels to any event listeners because that is handled in MainWindow.xaml.cs
        }

        /// <summary>
        /// Button to customize the side is clicked
        /// </summary>
        public void SideClicked(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new SideSelection(true));
        }

        /// <summary>
        /// Button to customize the drink is clicked
        /// </summary>
        public void DrinkClicked(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new DrinkSelection(true));
        }

        /// <summary>
        /// Button to customize the entree is clicked
        /// </summary>
        public void EntreeClicked(object sender, RoutedEventArgs args)
        {
            Page p = EntreeSelection.GetCustomizationPage(GetCurrentCombo().Entree);
            if (p != null)
            {
                NavigationService.Navigate(p);
            }
        }


        /// <summary>
        /// Button to customize the side is clicked
        /// </summary>
        public void SizeClicked(object sender, RoutedEventArgs args)
        {
            CretaceousCombo combo = GetCurrentCombo();
            if (combo != null)
            {
                combo.Size = (DinoDiner.Menu.Size)(sender as Button).Tag;
            }
        }

        /// <summary>
        /// Updates the displayed names of the combo's side and drink
        /// </summary>
        public void UpdateButtonLabels(object sender, PropertyChangedEventArgs args)
        {
            CretaceousCombo combo = GetCurrentCombo();
            if (combo != null)
            {
                sideButton.Content = combo.Side.BaseName();
                drinkButton.Content = combo.Drink.BaseName();
                entreeButton.Content = combo.Entree.ToString();
            }
        }

        /// <summary>
        /// Gets the order's currently selected combo, or null if one is not found
        /// </summary>
        /// <returns>the order's currently selected combo, or null if one is not found</returns>
        protected CretaceousCombo GetCurrentCombo()
        {
            if (DataContext is Order order)
            {
                return CollectionViewSource.GetDefaultView(order.Items).CurrentItem as CretaceousCombo;
            }

            return null;
        }
    }
}
