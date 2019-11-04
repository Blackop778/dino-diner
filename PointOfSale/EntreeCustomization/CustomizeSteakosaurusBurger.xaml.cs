/*CustomizeSteakosaurusBurger.xaml.cs
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
    /// Interaction logic for CustomizeSteakosaurusBurger.xaml
    /// </summary>
    public partial class CustomizeSteakosaurusBurger : Page
    {
        public CustomizeSteakosaurusBurger()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldBunClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is SteakosaurusBurger b)
            {
                b.HoldBun();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldPickleClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is SteakosaurusBurger b)
            {
                b.HoldPickle();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldKetchupClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is SteakosaurusBurger b)
            {
                b.HoldKetchup();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldMustardClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is SteakosaurusBurger b)
            {
                b.HoldMustard();
            }
        }

        private void DoneClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
