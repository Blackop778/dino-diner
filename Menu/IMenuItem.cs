/* IMenuItem.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// menu item interface
    /// </summary>
    public interface IMenuItem : INotifyPropertyChanged, ICloneable
    {
        /// <summary>
        /// Gets the item's price
        /// </summary>
        double Price { get; set; }
        /// <summary>
        /// Gets the item's calories
        /// </summary>
        uint Calories { get; set; }

        /// <summary>
        ///  Gets the item's ingredient list
        /// </summary>
        List<string> Ingredients { get; }
    }
}
