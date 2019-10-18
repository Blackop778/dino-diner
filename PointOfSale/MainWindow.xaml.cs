/* MainWindow.xaml.cs
 * Author: Nathan Faltermeier
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The available items in the menu
        /// </summary>
        public static DinoDiner.Menu.Menu menu = new DinoDiner.Menu.Menu();
        /// <summary>
        /// The current order
        /// </summary>
        public static Order order = new Order();

        public MainWindow()
        {
            InitializeComponent();
            list.ItemsSource = order.Items;
        }
    }
}
