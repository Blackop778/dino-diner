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
        // The drink the page has selected
        private Drink drink;
        public Action<Drink> Callback { get; set; }

        /// <summary>
        /// NOTE: DO NOT USE.
        /// this constructor is required by xaml. It will not work.
        /// </summary>
        public DrinkSelection() : this(null, null) { }

        /// <summary>
        /// Creates a drink selection page. Lets the user choose the size and ice, lemon, flavor, sweet, cream, decaf statuses as appropriate.
        /// </summary>
        /// <param name="callback">Gets called with the pages instance of the drink when a new drink is added to the order</param>
        /// <param name="drink">A drink for the page to start with, can be null</param>
        public DrinkSelection(Action<Drink> callback, Drink drink)
        {
            this.drink = drink;
            Callback = callback;
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

            if (drink != null)
                UpdateSpecialButtons();
        }

        /// <summary>
        /// A button to choose a drink is clicked
        /// </summary>
        public void DrinkClicked(object sender, RoutedEventArgs args)
        {
            drink = ((sender as Button).Tag as Drink).Clone() as Drink;
            Callback(drink);
            UpdateSpecialButtons();
        }

        /// <summary>
        /// A button to choose the drink's size is clicked
        /// </summary>
        public void SizeClicked(object sender, RoutedEventArgs args)
        {
            if (drink == null)
                return;

            drink.Size = (Size) (sender as Button).Tag;
        }

        /// <summary>
        /// Adds and hides the ice, lemon, flavor, sweet, cream, decaf buttons and changes their text based on the pages current drink
        /// </summary>
        private void UpdateSpecialButtons()
        {
            iceButton.Content = drink.Ice ? "Hold Ice" : "Add Ice";

            bool? lemon = null;
            bool? flavor = null;
            bool? sweet = null;
            bool? cream = null;
            bool? decaf = null;

            if (drink is Water w) {
                lemon = w.Lemon;
            } else if (drink is Tyrannotea t) {
                lemon = t.Lemon;
                sweet = t.Sweet;
            } else if (drink is Sodasaurus s) {
                flavor = true;
            } else if (drink is JurassicJava j) {
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
            if (drink == null)
                return;

            drink.Ice = !drink.Ice;
            UpdateSpecialButtons();
        }

        /// <summary>
        /// See method name
        /// </summary>
        public void ToggleLemon(object sender, RoutedEventArgs args)
        {
            if (drink == null)
                return;

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
            if (drink == null)
                return;

            NavigationService.Navigate(new FlavorSelection(FlavorCallback));
        }

        /// <summary>
        /// Flavor selection page calls this method when a flavor is chosen
        /// </summary>
        /// <param name="flavor">The sodasaurus drink's flavor</param>
        public void FlavorCallback(SodasaurusFlavor flavor)
        {
            if (drink is Sodasaurus s)
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
            if (drink == null)
                return;

            if (drink is Tyrannotea t)
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
            if (drink == null)
                return;

            if (drink is JurassicJava j)
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
            if (drink == null)
                return;

            if (drink is JurassicJava j)
            {
                j.Decaf = !j.Decaf;
                UpdateSpecialButtons();
            }
        }
    }
}
