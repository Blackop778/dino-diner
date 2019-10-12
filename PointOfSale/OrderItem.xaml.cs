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
    /// Interaction logic for OrderItem.xaml
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

        private void OnItemChanged(DependencyPropertyChangedEventArgs e)
        {
            if (Item != null)
            {
                if (Item is CretaceousCombo c)
                {
                    text.Text = Item.ToString();
                }
                else if (Item is Drink d)
                {
                    text.Text = Item.ToString();
                }
                else
                {
                    text.Text = Item.ToString();
                }
            }
        }

        public OrderItem()
        {
            InitializeComponent();
            
        }
    }
}
