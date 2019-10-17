/* IOrderItem.cs
 * Author: Nathan Faltermeier
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DinoDiner.Menu
{
    interface IOrderItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The item's price
        /// </summary>
        double Price { get; }
        /// <summary>
        /// A description of the item
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Special instructions for the item
        /// </summary>
        string[] Special { get; }
    }
}
