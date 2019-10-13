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
    /// Interaction logic for CustomizeCombo.xaml
    /// </summary>
    public partial class CustomizeCombo : Page
    {
        private CretaceousCombo combo;

        public CustomizeCombo() : this(null) {}

        public CustomizeCombo(CretaceousCombo combo)
        {
            this.combo = combo;
            combo.PropertyChanged += UpdateDrinkSideButtons;
            InitializeComponent();
            smallButton.Tag = DinoDiner.Menu.Size.Small;
            mediumButton.Tag = DinoDiner.Menu.Size.Medium;
            largeButton.Tag = DinoDiner.Menu.Size.Large;
            UpdateDrinkSideButtons(null, null);
        }

        /// <summary>
        /// Callback for the side selection page
        /// </summary>
        public void SideSelectionCallback(Side side)
        {
            combo.Side = side;
        }

        /// <summary>
        /// Callback for the drink selection page
        /// </summary>
        public void DrinkSelectionCallback(Drink drink)
        {
            combo.Drink = drink;
        }

        /// <summary>
        /// Button to customize the side is clicked
        /// </summary>
        public void SideClicked(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new SideSelection(SideSelectionCallback, combo.Side));
        }

        /// <summary>
        /// Button to customize the drink is clicked
        /// </summary>
        public void DrinkClicked(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new DrinkSelection(DrinkSelectionCallback, combo.Drink));
        }

        /// <summary>
        /// Button to customize the side is clicked
        /// </summary>
        public void SizeClicked(object sender, RoutedEventArgs args)
        {
            combo.Size = (DinoDiner.Menu.Size) (sender as Button).Tag;
        }

        /// <summary>
        /// Updates the displayed names of the combo's side and drink
        /// </summary>
        public void UpdateDrinkSideButtons(object sender, PropertyChangedEventArgs args)
        {
            sideButton.Content = combo.Side.BaseName();
            drinkButton.Content = combo.Drink.BaseName();
        }
    }
}
