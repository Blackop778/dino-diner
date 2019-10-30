/* DrinkSelection.xaml.cs
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
using Size = DinoDiner.Menu.Size;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for FlavorSelection.xaml
    /// </summary>
    public partial class DrinkSelection : Page
    {
        /// <summary>
        /// Whether or not this page is modifying a combo
        /// </summary>
        public bool ModifyingCombo { get; set; }

        /// <summary>
        /// Creates a drink selection that does not modify a combo. Lets the user choose the size and ice, lemon, flavor, sweet, cream, decaf statuses as appropriate.
        /// </summary>
        public DrinkSelection() : this(false) { }

        /// <summary>
        /// Creates a drink selection page that may or may not be modifying a combo. Lets the user choose the size and ice, lemon, flavor, sweet, cream, decaf statuses as appropriate.
        /// </summary>
        /// <param name="ModifyingCombo">Whether or not this page is modifying a combo</param>
        public DrinkSelection(bool ModifyingCombo)
        {
            this.ModifyingCombo = ModifyingCombo;
            InitializeComponent();
            foreach (Drink d in MainWindow.menu.AvailableDrinks)
            {
                Button b = new Button
                {
                    Content = d.BaseName(),
                    Tag = d,
                };
                b.Click += DrinkClicked;
                drinkPanel.Children.Add(b);
            }

            smallButton.Tag = Size.Small;
            mediumButton.Tag = Size.Medium;
            largeButton.Tag = Size.Large;

            UpdateSpecialButtons();
        }

        /// <summary>
        /// A button to choose a drink is clicked
        /// </summary>
        public void DrinkClicked(object sender, RoutedEventArgs args)
        {
            if (DataContext is Order order)
            {
                DrinkSelected(((sender as Button).Tag as Drink).Clone() as Drink);
                UpdateSpecialButtons();
            }
        }

        /// <summary>
        /// A button to choose the drink's size is clicked
        /// </summary>
        public void SizeClicked(object sender, RoutedEventArgs args)
        {
            Drink drink = GetCurrentDrink();
            if (drink != null)
            {
                drink.Size = (Size)(sender as Button).Tag;
            }
        }

        /// <summary>
        /// Adds and hides the ice, lemon, flavor, sweet, cream, decaf buttons and changes their text based on the pages current drink
        /// </summary>
        internal void UpdateSpecialButtons()
        {
            Drink drink = GetCurrentDrink();
            if (drink != null)
                iceButton.Content = drink.Ice ? "Hold Ice" : "Add Ice";

            bool? lemon = null;
            bool? flavor = null;
            bool? sweet = null;
            bool? cream = null;
            bool? decaf = null;

            if (drink is Water w)
            {
                lemon = w.Lemon;
            }
            else if (drink is Tyrannotea t)
            {
                lemon = t.Lemon;
                sweet = t.Sweet;
            }
            else if (drink is Sodasaurus)
            {
                flavor = true;
            }
            else if (drink is JurassicJava j)
            {
                cream = j.RoomForCream;
                decaf = j.Decaf;
            }

            if (lemon != null)
            {
                lemonButton.Visibility = Visibility.Visible;
                lemonButton.Content = lemon.Value ? "Hold Lemon" : "Add Lemon";
            }
            else
            {
                lemonButton.Visibility = Visibility.Collapsed;
            }

            if (flavor != null)
            {
                flavorButton.Visibility = Visibility.Visible;
            }
            else
            {
                flavorButton.Visibility = Visibility.Collapsed;
            }

            if (sweet != null)
            {
                sweetButton.Visibility = Visibility.Visible;
                sweetButton.Content = sweet.Value ? "Unsweeten" : "Make Sweet";
            }
            else
            {
                sweetButton.Visibility = Visibility.Collapsed;
            }

            if (cream != null)
            {
                creamButton.Visibility = Visibility.Visible;
                creamButton.Content = cream.Value ? "Hold Cream" : "Add Cream";
            }
            else
            {
                creamButton.Visibility = Visibility.Collapsed;
            }

            if (decaf != null)
            {
                decafButton.Visibility = Visibility.Visible;
                decafButton.Content = decaf.Value ? "Make Not Decaf" : "Make Decaf";
            }
            else
            {
                decafButton.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// See method name
        /// </summary>
        public void ToggleIce(object sender, RoutedEventArgs args)
        {
            Drink drink = GetCurrentDrink();
            if (drink != null)
            {
                drink.Ice = !drink.Ice;
                UpdateSpecialButtons();
            }
        }

        /// <summary>
        /// See method name
        /// </summary>
        public void ToggleLemon(object sender, RoutedEventArgs args)
        {
            Drink drink = GetCurrentDrink();
            if (drink is Water w)
            {
                w.Lemon = !w.Lemon;
                UpdateSpecialButtons();
            }
            else if (drink is Tyrannotea t)
            {
                t.Lemon = !t.Lemon;
                UpdateSpecialButtons();
            }
        }

        /// <summary>
        /// Shows a page to choose a flavor for the current sodasaurus drink
        /// </summary>
        public void FlavorClicked(object sender, RoutedEventArgs args)
        {
            if (GetCurrentDrink() is Sodasaurus s)
            {
                NavigationService.Navigate(new FlavorSelection(FlavorCallback));
            }
        }

        /// <summary>
        /// Flavor selection page calls this method when a flavor is chosen
        /// </summary>
        /// <param name="flavor">The sodasaurus drink's flavor</param>
        public void FlavorCallback(SodasaurusFlavor flavor)
        {
            if (GetCurrentDrink() is Sodasaurus s)
            {
                s.Flavor = flavor;
                UpdateSpecialButtons();
            }
        }

        /// <summary>
        /// See method name
        /// </summary>
        public void ToggleSweet(object sender, RoutedEventArgs args)
        {
            if (GetCurrentDrink() is Tyrannotea t)
            {
                t.Sweet = !t.Sweet;
                UpdateSpecialButtons();
            }
        }

        /// <summary>
        /// See method name
        /// </summary>
        public void ToggleCream(object sender, RoutedEventArgs args)
        {
            if (GetCurrentDrink() is JurassicJava j)
            {
                j.RoomForCream = !j.RoomForCream;
                UpdateSpecialButtons();
            }
        }

        /// <summary>
        /// See method name
        /// </summary>
        public void ToggleDecaf(object sender, RoutedEventArgs args)
        {
            if (GetCurrentDrink() is JurassicJava j)
            {
                j.Decaf = !j.Decaf;
                UpdateSpecialButtons();
            }
        }

        /// <summary>
        /// Callback for the done button being clicked
        /// </summary>
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        /// <summary>
        /// Gets the drink (in a combo or not) the user has selected in the order, or null if one is not found
        /// </summary>
        /// <returns>the drink (in a combo or not) the user has selected in the order, or null if one is not found</returns>
        protected Drink GetCurrentDrink()
        {
            if (DataContext is Order order)
            {
                if (!ModifyingCombo)
                    return CollectionViewSource.GetDefaultView(order.Items).CurrentItem as Drink;
                else
                    return (CollectionViewSource.GetDefaultView(order.Items).CurrentItem as CretaceousCombo)?.Drink;
            }

            return null;
        }

        /// <summary>
        /// Callback for when a drink is selected. Either adds a new drink or sets the combo's drink.
        /// </summary>
        /// <param name="item">A new instance of the selected drink</param>
        protected void DrinkSelected(Drink item)
        {
            if (DataContext is Order order)
            {
                if (!ModifyingCombo)
                {
                    order.Items.Add(item);
                    CollectionViewSource.GetDefaultView(order.Items).MoveCurrentToLast();
                }
                else if (CollectionViewSource.GetDefaultView(order.Items).CurrentItem is CretaceousCombo combo)
                {
                    combo.Drink = item;
                }
            }
        }
    }
}
