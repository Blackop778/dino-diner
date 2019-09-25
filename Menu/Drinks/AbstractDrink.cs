/* AbstractDrink.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu.Drinks
{
    /// <summary>
    /// Represents a drink. Can be in multiple sizes and by default comes with ice.
    /// </summary>
    public abstract class AbstractDrink : AbstractSizedMenuItem
    {
        /// <summary>
        /// Whether or not the drink comes with ice
        /// </summary>
        public bool Ice { get; protected set; }

        /// <summary>
        /// Creates a drink with the specified ice status
        /// </summary>
        /// <param name="ice"></param>
        public AbstractDrink(bool ice)
        {
            Ice = ice;
        }

        /// <summary>
        ///  Removes ice from the drink
        /// </summary>
        public void HoldIce()
        {
            Ice = false;
        }
    }
}
