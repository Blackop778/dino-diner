/*CustomizeTRexKingBurger.xaml.cs
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
    /// Interaction logic for CustomizeTRexKingBurger.xaml
    /// </summary>
    public partial class CustomizeTRexKingBurger : Page
    {
        public CustomizeTRexKingBurger()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldBunClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is TRexKingBurger b)
            {
                b.HoldBun();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldPickleClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is TRexKingBurger b)
            {
                b.HoldPickle();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldKetchupClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is TRexKingBurger b)
            {
                b.HoldKetchup();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldMustardClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is TRexKingBurger b)
            {
                b.HoldMustard();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldLettuceClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is TRexKingBurger b)
            {
                b.HoldLettuce();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldTomatoClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is TRexKingBurger b)
            {
                b.HoldTomato();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldOnionClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is TRexKingBurger b)
            {
                b.HoldOnion();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldMayoClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is TRexKingBurger b)
            {
                b.HoldMayo();
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
