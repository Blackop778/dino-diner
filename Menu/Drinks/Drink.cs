/* Drink.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Represents a drink. Can be in multiple sizes and by default comes with ice.
    /// </summary>
    public abstract class Drink : AbstractSizedMenuItem, INotifyPropertyChanged
    {
        // Declare event handler
        public event PropertyChangedEventHandler PropertyChanged;
        //backing variable
        private bool ice;

        /// <summary>
        /// Whether or not the drink comes with ice
        /// </summary>
        public bool Ice {
            get => ice;
            set { ice = value; OnPropertyChanged("Ice"); }
        }

        /// <summary>
        /// Creates a drink with the specified ice status
        /// </summary>
        /// <param name="ice"></param>
        public Drink(bool ice)
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

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
