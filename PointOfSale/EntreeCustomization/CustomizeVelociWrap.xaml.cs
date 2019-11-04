/*CustomizeVelociWrap.xaml.cs
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
    /// Interaction logic for CustomizeVelociWrap.xaml
    /// </summary>
    public partial class CustomizeVelociWrap : Page
    {
        public CustomizeVelociWrap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldDressingClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is VelociWrap b)
            {
                b.HoldDressing();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldLettuceClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is VelociWrap b)
            {
                b.HoldLettuce();
            }
        }

        /// <summary>
        /// Removes the given ingredient from the entree
        /// </summary>
        private void HoldCheeseClick(object sender, RoutedEventArgs e)
        {
            if (EntreeSelection.GetCurrentEntree(this) is VelociWrap b)
            {
                b.HoldCheese();
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
