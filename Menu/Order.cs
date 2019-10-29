/* Order.cs
 * Author: Nathan Faltermeier
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace DinoDiner.Menu
{
    public class Order : INotifyPropertyChanged
    {
        // backing variable
        private ObservableCollection<IOrderItem> items;

        // PropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property was changed
        /// </summary>
        /// <param name="name">Name of the changed property</param>
        protected void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Items in the order
        /// </summary>
        public ObservableCollection<IOrderItem> Items {
            get => items;
            set {
                if (items != null) items.CollectionChanged -= Items_CollectionChanged;
                items = value;
                if (items != null) items.CollectionChanged += Items_CollectionChanged;
            }
        }

        /// <summary>
        /// Rate of sales tax
        /// </summary>
        public double SalesTaxRate { get; protected set; }

        /// <summary>
        /// Price before sales tax
        /// </summary>
        public double SubtotalCost
        {
            get
            {
                double total = 0;
                foreach (IOrderItem i in Items)
                {
                    total += i.Price;
                }

                return total >= 0 ? total : 0;
            }
        }

        /// <summary>
        /// The cost from sales tax
        /// </summary>
        public double SalesTaxCost => SubtotalCost * SalesTaxRate;

        /// <summary>
        /// The cost including sales tax
        /// </summary>
        public double TotalCost => SubtotalCost + SalesTaxCost;

        public Order()
        {
            Items = new ObservableCollection<IOrderItem>();
            SalesTaxRate = .1;
        }
        
        /// <summary>
        /// Handles changes to Items
        /// </summary>
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (IOrderItem i in e.NewItems)
                {
                    i.PropertyChanged += OnThingInItemsPropertyChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (IOrderItem i in e.OldItems)
                {
                    i.PropertyChanged -= OnThingInItemsPropertyChanged;
                }
            }

            OnStuffInItemsChanged();
        }

        private void OnThingInItemsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnStuffInItemsChanged();
        }

        private void OnStuffInItemsChanged()
        {
            NotifyPropertyChanged("SubtotalCost");
            NotifyPropertyChanged("SalesTaxCost");
            NotifyPropertyChanged("TotalCost");
        }
    }
}
