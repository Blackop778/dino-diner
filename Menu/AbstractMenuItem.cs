/* AbstractMenuItem.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Abstract menu item
    /// </summary>
    public abstract class AbstractMenuItem : IMenuItem
    {
        // Declare event handler
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property was changed
        /// </summary>
        /// <param name="name">Name of the changed property</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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

        /// <summary>
        /// Returns a shallow copy of this object
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}
