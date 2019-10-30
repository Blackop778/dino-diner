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
        /// <summary>
        /// Whether or not this page is modifying a combo
        /// </summary>
        public bool ModifyingCombo { get; set; }

        /// <summary>
        /// Creates a side selection that does not modify a combo.
        /// </summary>
        public SideSelection() : this(false) { }

        /// <summary>
        /// Creates a side selection page that may or may not be modifying a combo.
        /// </summary>
        /// <param name="ModifyingCombo">Whether or not this page is modifying a combo</param>
        public SideSelection(bool ModifyingCombo)
        {
            this.ModifyingCombo = ModifyingCombo;
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
            SideSelected(((sender as Button).Tag as Side).Clone() as Side);
        }

        /// <summary>
        /// Sets the side's size
        /// </summary>
        public void SizeClicked(object sender, RoutedEventArgs args)
        {
            Side side = GetCurrentSide();
            if (side != null)
            {
                side.Size = (Size)(sender as Button).Tag;

                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
        }

        /// <summary>
        /// Gets the side (in a combo or not) the user has selected in the order, or null if one is not found
        /// </summary>
        /// <returns>the side (in a combo or not) the user has selected in the order, or null if one is not found</returns>
        protected Side GetCurrentSide()
        {
            if (DataContext is Order order)
            {
                if (!ModifyingCombo)
                    return CollectionViewSource.GetDefaultView(order.Items).CurrentItem as Side;
                else
                    return (CollectionViewSource.GetDefaultView(order.Items).CurrentItem as CretaceousCombo)?.Side;
            }

            return null;
        }

        /// <summary>
        /// Callback for when a side is selected. Either adds a new side or sets the combo's side.
        /// </summary>
        /// <param name="item">A new instance of the selected side</param>
        protected void SideSelected(Side item)
        {
            if (DataContext is Order order)
            {
                if (!ModifyingCombo)
                {
                    order.Items.Add(item);
                    CollectionViewSource.GetDefaultView(order.Items).MoveCurrentToLast();
                }
                else if (CollectionViewSource.GetDefaultView(order.Items).CurrentItem is CretaceousCombo combo)
                {
                    combo.Side = item;
                }
            }
        }
    }
}
