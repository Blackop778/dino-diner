﻿/* AbstractMenuItem.cs
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
    public abstract class AbstractMenuItem : IMenuItem
    {
        /// <summary>
        /// Gets the item's price
        /// </summary>
        public virtual double Price { get; set; }
        /// <summary>
        /// Gets the item's calories
        /// </summary>
        public virtual uint Calories { get; set; }

        /// <summary>
        ///  Gets the item's ingredient list
        /// </summary>
        public abstract List<string> Ingredients { get; }
    }
}
