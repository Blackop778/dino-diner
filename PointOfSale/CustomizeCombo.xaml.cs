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
        }

        public void SideSelectionCallback(Side drink)
        {

        }

        public void DrinkSelectionCallback(Drink drink)
        {

        }

        public void SideCallback(object sender, RoutedEventArgs args)
        {

        }

        public void DrinkCallback(object sender, RoutedEventArgs args)
        {

        }

        public void SizeCallback(object sender, RoutedEventArgs args)
        {

        }
    }
}
