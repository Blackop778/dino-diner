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

        public DrinkSelection() : this(null) { }

        public DrinkSelection(Action<Drink> callback)
        {
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
        }

        public void DrinkClicked(object sender, RoutedEventArgs args)
        {
            drink = ((sender as Button).Tag as Drink).Clone() as Drink;
            Callback(drink);
            UpdateSpecialButtons();
        }

        public void SizeClicked(object sender, RoutedEventArgs args)
        {
            drink.Size = (Size) (sender as Button).Tag;
        }

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

        public void ToggleIce(object sender, RoutedEventArgs args)
        {
            drink.Ice = !drink.Ice;
            UpdateSpecialButtons();
        }

        public void ToggleLemon(object sender, RoutedEventArgs args)
        {
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

        public void FlavorClicked(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new FlavorSelection(FlavorCallback));
        }

        public void FlavorCallback(SodasaurusFlavor flavor)
        {
            if (drink is Sodasaurus s)
            {
                s.Flavor = flavor;
                UpdateSpecialButtons();
            }
        }

        public void ToggleSweet(object sender, RoutedEventArgs args)
        {
            if (drink is Tyrannotea t)
            {
                t.Sweet = !t.Sweet;
                UpdateSpecialButtons();
            }
        }

        public void ToggleCream(object sender, RoutedEventArgs args)
        {
            if (drink is JurassicJava j)
            {
                j.RoomForCream = !j.RoomForCream;
                UpdateSpecialButtons();
            }
        }

        public void ToggleDecaf(object sender, RoutedEventArgs args)
        {
            if (drink is JurassicJava j)
            {
                j.Decaf = !j.Decaf;
                UpdateSpecialButtons();
            }
        }
    }
}
