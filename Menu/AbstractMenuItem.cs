/* AbstractMenuItem.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Abstract menu item
    /// </summary>
    public abstract class AbstractMenuItem
    {
        /// <summary>
        /// Gets the item's price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Gets the item's calories
        /// </summary>
        public uint Calories { get; set; }

        /// <summary>
        ///  Gets the item's ingredient list
        /// </summary>
        public abstract List<string> Ingredients { get; }
    }
}
