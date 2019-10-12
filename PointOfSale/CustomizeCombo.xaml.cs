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
    /// Interaction logic for CustomizeCombo.xaml
    /// </summary>
    public partial class CustomizeCombo : Page
    {
        public CretaceousCombo Combo { get; set; }

        public CustomizeCombo() : this(null) {}

        public CustomizeCombo(CretaceousCombo combo)
        {
            Combo = combo;
            InitializeComponent();
            smallButton.Tag = DinoDiner.Menu.Size.Small;
            mediumButton.Tag = DinoDiner.Menu.Size.Medium;
            largeButton.Tag = DinoDiner.Menu.Size.Large;
        }

        public void SideSelectionCallback(Side side)
        {
            Combo.Side = side;
        }

        public void DrinkSelectionCallback(Drink drink)
        {
            Combo.Drink = drink;
        }

        public void SideClicked(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new ComboSelection());
        }

        public void DrinkClicked(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new ComboSelection());
        }

        public void SizeClicked(object sender, RoutedEventArgs args)
        {
            Combo.Size = (DinoDiner.Menu.Size) (sender as Button).Tag;
        }
    }
}
