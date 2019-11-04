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
                            combo.PropertyChanged -= comboPage.UpdateButtonLabels;
                    }
                }

                comboPage.UpdateButtonLabels(null, null);

                if (e.AddedItems != null)
                {
                    foreach (IOrderItem item in e.AddedItems)
                    {
                        if (item is CretaceousCombo combo)
                            combo.PropertyChanged += comboPage.UpdateButtonLabels;
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
