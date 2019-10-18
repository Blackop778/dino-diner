/* Order.cs
 * Author: Nathan Faltermeier
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DinoDiner.Menu
{
    public class Order
    {
        /// <summary>
        /// Items in the order
        /// </summary>
        public ObservableCollection<IOrderItem> Items { get; set; }
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
        }
    }
}
