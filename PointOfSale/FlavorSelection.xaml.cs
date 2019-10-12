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
    /// Interaction logic for FlavorSelection.xaml
    /// </summary>
    public partial class FlavorSelection : Page
    {
        public Action<SodasaurusFlavor> Callback { get; set; }

        public FlavorSelection() : this(null) { }

        public FlavorSelection(Action<SodasaurusFlavor> callback)
        {
            Callback = callback;
            InitializeComponent();
            foreach (SodasaurusFlavor f in Enum.GetValues(typeof(SodasaurusFlavor)))
            {
                Button b = new Button
                {
                    Content = f.ToString(),
                    Tag = f,
                };
                b.Click += OnButtonClicked;
                flavorPanel.Children.Add(b);
            }
        }

        public void OnButtonClicked(object sender, RoutedEventArgs args)
        {
            Callback((SodasaurusFlavor) (sender as Button).Tag );
        }
    }
}
