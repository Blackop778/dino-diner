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
    public abstract class AbstractMenuItem : IMenuItem, IOrderItem
    {
        // backing variables
        private double price;
        private uint calories;

        // Declare event handler
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property was changed
        /// </summary>
        /// <param name="name">Name of the changed property</param>
        protected void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Gets the item's price
        /// </summary>
        public virtual double Price {
            get => price;
            set
            {
                price = value;
                NotifyPropertyChanged("Price");
            }
        }

        /// <summary>
        /// Gets the item's calories
        /// </summary>
        public virtual uint Calories
        {
            get => calories;
            set
            {
                calories = value;
                NotifyPropertyChanged("Calories");
            }
        }

        /// <summary>
        ///  Gets the item's ingredient list
        /// </summary>
        public abstract List<string> Ingredients { get; }

        /// <summary>
        /// Description of the item
        /// </summary>
        public string Description => ToString();

        /// <summary>
        /// Special instructions for the item
        /// </summary>
        public abstract string[] Special { get; }

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
