/* MenuCategorySelection.xaml.cs
 * Author: Nathan Faltermeier
 */
using DinoDiner.Menu;
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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuCategorySelection.xaml
    /// </summary>
    public partial class MenuCategorySelection : Page
    {
        public MenuCategorySelection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates to the given selection page
        /// </summary>
        public void SelectCombo(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new ComboSelection());
        }

        /// <summary>
        /// Navigates to the given selection page
        /// </summary>
        public void SelectEntree(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new EntreeSelection());
        }

        /// <summary>
        /// Navigates to the given selection page
        /// </summary>
        public void SelectDrink(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new DrinkSelection(AddItemToOrder, null));
        }

        /// <summary>
        /// Navigates to the given selection page
        /// </summary>
        public void SelectSide(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new SideSelection(AddItemToOrder, null));
        }

        /// <summary>
        /// Callback for the drink and side selection pages
        /// </summary>
        public void AddItemToOrder(IOrderItem item)
        {
            if (DataContext is Order order)
            {
                order.Items.Add(item);
                CollectionViewSource.GetDefaultView(order.Items).MoveCurrentToLast();
            }
        }
    }
}
