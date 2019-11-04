/*CustomizeBrontowurst.xaml.cs
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
    /// Interaction logic for CustomizeBrontowurst.xaml
    /// </summary>
    public partial class CustomizeBrontowurst : Page
    {
        public CustomizeBrontowurst()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldBunClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is Brontowurst b)
            {
                b.HoldBun();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldPeppersClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is Brontowurst b)
            {
                b.HoldPeppers();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldOnionClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is Brontowurst b)
            {
                b.HoldOnion();
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
