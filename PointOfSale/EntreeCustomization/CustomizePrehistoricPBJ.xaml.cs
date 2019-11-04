/*CustomizePrehistoricPBJ.xaml.cs
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
    /// Interaction logic for CustomizePrehistoricPBJ.xaml
    /// </summary>
    public partial class CustomizePrehistoricPBJ : Page
    {
        public CustomizePrehistoricPBJ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldJellyClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is PrehistoricPBJ b)
            {
                b.HoldJelly();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldPeanutButterClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is PrehistoricPBJ b)
            {
                b.HoldPeanutButter();
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
