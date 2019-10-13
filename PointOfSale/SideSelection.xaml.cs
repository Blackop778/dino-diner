/* SideSelection.xaml.cs
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
using Size = DinoDiner.Menu.Size;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for FlavorSelection.xaml
    /// </summary>
    public partial class SideSelection : Page
    {
        // The drink the page has selected
        private Side side;
        public Action<Side> Callback { get; set; }

        /// <summary>
        /// NOTE: DO NOT USE.
        /// this constructor is required by xaml. It will not work.
        /// </summary>
        public SideSelection() : this(null, null) { }

        /// <summary>
        /// Creates a side selection page. Lets the user choose the size.
        /// </summary>
        /// <param name="callback">Gets called with the pages instance of the side when a new side is added to the order</param>
        /// <param name="side">A side for the page to start with, can be null</param>
        public SideSelection(Action<Side> callback, Side side)
        {
            this.side = side;
            Callback = callback;
            InitializeComponent();
            foreach (Side s in MainWindow.menu.AvailableSides)
            {
                Button b = new Button
                {
                    Content = s.BaseName(),
                    Tag = s,
                };
                b.Click += SideClicked;
                sidePanel.Children.Add(b);
            }

            smallButton.Tag = Size.Small;
            mediumButton.Tag = Size.Medium;
            largeButton.Tag = Size.Large;
        }

        /// <summary>
        /// Sets the side's size
        /// </summary>
        public void SideClicked(object sender, RoutedEventArgs args)
        {
            side = ((sender as Button).Tag as Side).Clone() as Side;
            Callback(side);
        }

        /// <summary>
        /// Sets the side's size
        /// </summary>
        public void SizeClicked(object sender, RoutedEventArgs args)
        {
            side.Size = (Size)(sender as Button).Tag;
        }
    }
}
