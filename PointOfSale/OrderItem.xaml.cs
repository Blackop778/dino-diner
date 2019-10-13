/* OrderItem.xaml.cs
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
    /// Displays an order item, with extra information than the item's name when applicable.
    /// </summary>
    public partial class OrderItem : UserControl
    {
        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(IMenuItem), typeof(OrderItem), new PropertyMetadata(null,
         new PropertyChangedCallback(OnItemChanged)));

        public IMenuItem Item {
            get { return (IMenuItem) GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }

        }

        private static void OnItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OrderItem UserControl1Control = d as OrderItem;
            UserControl1Control.OnItemChanged(e);
        }

        /// <summary>
        /// Updates the displayed menu item's info
        /// </summary>
        private void OnItemChanged(DependencyPropertyChangedEventArgs e)
        {
            if (Item != null)
            {
                if (Item is CretaceousCombo c)
                {
                    text.Text = c.ToString() + "\n\t- " + c.Side + "\n\t- " + c.Drink;
                }
                else if (Item is Drink d)
                {
                    text.Text = d.ToString();
                }
                else
                {
                    text.Text = Item.ToString();
                }
            }
        }

        /// <summary>
        /// NOTE: Item property must be set for this control to work
        /// </summary>
        public OrderItem()
        {
            InitializeComponent();
        }
    }
}
