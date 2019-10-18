/* Water.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Water. Comes with Ice by default, but no lemon.
    /// </summary>
    public class Water : Drink
    {
        // Backing variable
        private bool lemon;

        /// <summary>
        /// Creates a default Water. Comes with Ice by default, but no lemon.
        /// </summary>
        public Water()
        {
            Lemon = false;
        }

        /// <summary>
        /// The drink's ingredients
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>() { "Water" };
                if (Lemon) ingredients.Add("Lemon");
                return ingredients;
            }
        }

        /// <summary>
        /// Sets the drink's Size. Adjusts the Price and Calories accordingly.
        /// </summary>
        public override Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                Price = .10;
                Calories = 0;
                
            }
        }

        /// <summary>
        /// Whether or not this drink has a lemon
        /// </summary>
        public bool Lemon {
            get => lemon;
            set { lemon = value; NotifyPropertyChanged("Lemon"); NotifyPropertyChanged("Special"); }
        }

        /// <summary>
        /// Adds a lemon to the drink.
        /// </summary>
        public void AddLemon()
        {
            Lemon = true;
        }

        /// <summary>
        /// The drink's basename with no additional words
        /// </summary>
        /// <returns>The drink's basename with no additional words</returns>
        public override string BaseName()
        {
            return "Water";
        }

        /// <summary>
        /// Special instructions for this order item
        /// </summary>
        public override string[] Special
        {
            get
            {
                List<string> list = SpecialList;
                if (Lemon) list.Add("Add Lemon");
                return list.ToArray();
            }
        }
    }
}
