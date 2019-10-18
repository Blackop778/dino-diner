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
        private Size size;

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        public virtual Size Size {
            get => size;
            set {
                size = value;
                NotifyPropertyChanged("Size");
                NotifyPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Creates a small menu item
        /// </summary>
        public AbstractSizedMenuItem()
        {
            Size = Size.Small;
        }

        /// <summary>
        /// Returns the item's size
        /// </summary>
        /// <returns>The menu item's size</returns>
        public override string ToString()
        {
            return Size.ToString();
        }
    }
}
