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
    public class Water : AbstractDrink
    {
        /// <summary>
        /// Creates a default Water. Comes with Ice by default, but no lemon.
        /// </summary>
        public Water() : base(true)
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
            get => size;
            set
            {
                size = value;
                Price = .10;
                Calories = 0;
            }
        }

        /// <summary>
        /// Whether or not this drink has a lemon
        /// </summary>
        public bool Lemon { get; protected set; }

        /// <summary>
        /// Adds a lemon to the drink.
        /// </summary>
        public void AddLemon()
        {
            Lemon = true;
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "Water";
        }
    }
}
