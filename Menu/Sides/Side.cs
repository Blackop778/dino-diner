/* Side.cs
 * By: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu.Sides
{
    /// <summary>
    /// The sizes for side items
    /// </summary>
    public enum Size
    {
        Small,
        Medium, 
        Large
    }

    /// <summary>
    /// Represents a side item. Comes in multiple sizes and defaults to small.
    /// </summary>
    public abstract class Side : AbstractMenuItem
    {
        // Backing variable
        protected Size size;

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        public abstract Size Size { get; set; }

        public Side()
        {
            Size = Size.Small;
        }
    }
}
