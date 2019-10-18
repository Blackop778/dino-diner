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
    public abstract class Drink : AbstractSizedMenuItem
    {
        //backing variable
        private bool ice;

        /// <summary>
        /// Whether or not the drink comes with ice
        /// </summary>
        public bool Ice {
            get => ice;
            set { ice = value; NotifyPropertyChanged("Ice"); NotifyPropertyChanged("Special"); }
        }

        /// <summary>
        /// Whether or not a drink comes with Ice by default
        /// </summary>
        public virtual bool IceByDefault => true;

        /// <summary>
        /// Creates a drink with it's default ice status
        /// </summary>
        public Drink()
        {
            Ice = IceByDefault;
        }

        /// <summary>
        ///  Removes ice from the drink
        /// </summary>
        public void HoldIce()
        {
            Ice = false;
        }

        /// <summary>
        /// The drink's basename with no additional words
        /// </summary>
        /// <returns>The drink's basename with no additional words</returns>
        public abstract string BaseName();

        /// <summary>
        /// Returns the drink's size followed by it's basename
        /// </summary>
        /// <returns>the drink's size followed by it's basename</returns>
        public override string ToString()
        {
            return $"{Size} {BaseName()}";
        }

        public List<string> SpecialList
        {
            get
            {
                List<string> special = new List<string>();
                if (Ice != IceByDefault)
                {
                    if (Ice) special.Add("Add Ice");
                    else special.Add("Hold Ice");
                }

                return special;
            }
        }
    }
}
