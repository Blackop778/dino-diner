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

        public MainWindow()
        {
            InitializeComponent();
            orderControl.itemsList.SelectionChanged += ItemsList_SelectionChanged;
            frame.Navigating += Frame_Navigating;
        }

        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (frame.Content is CustomizeCombo oldComboPage)
            {

            }
            else if (e.Content is CustomizeCombo newComboPage)
            {
                Console.WriteLine("yay");
            }
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (frame.Content is DrinkSelection d)
            {
                d.UpdateSpecialButtons();
            }
            else if (frame.Content is CustomizeCombo comboPage)
            {
                if (e.RemovedItems != null)
                {
                    foreach (IOrderItem item in e.RemovedItems)
                    {
                        if (item is CretaceousCombo combo)
                            combo.PropertyChanged -= comboPage.UpdateDrinkSideButtons;
                    }
                }

                comboPage.UpdateDrinkSideButtons(null, null);

                if (e.AddedItems != null)
                {
                    foreach (IOrderItem item in e.AddedItems)
                    {
                        if (item is CretaceousCombo combo)
                            combo.PropertyChanged += comboPage.UpdateDrinkSideButtons;
                    }
                }
            }
        }

        private void PassOnDataContext()
        {
            if (frame.Content is Page p)
            {
                p.DataContext = DataContext;
            }
        }

        private void frame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            PassOnDataContext();
        }

        private void frame_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PassOnDataContext();
        }
    }
}
