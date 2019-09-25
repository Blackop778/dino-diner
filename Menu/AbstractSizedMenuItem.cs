/* AbstractSizedMenuItem.cs
 * By: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The sizes for the menu item
    /// </summary>
    public enum Size
    {
        Small,
        Medium, 
        Large
    }

    /// <summary>
    /// Represents a menu item that comes in multiple sizes. Defaults to small.
    /// </summary>
    public abstract class AbstractSizedMenuItem : AbstractMenuItem
    {
        // Backing variable
        protected Size size;

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        public abstract Size Size { get; set; }

        public AbstractSizedMenuItem()
        {
            Size = Size.Small;
        }
    }
}
