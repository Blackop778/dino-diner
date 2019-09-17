/* Fryceritops.cs
 * By: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu.Sides
{
    /// <summary>
    /// The Fryceritops side class
    /// </summary>
    public class Fryceritops : Side
    {
        /// <summary>
        /// The ingredients in the side
        /// </summary>
        public override List<string> Ingredients => new List<string>() { "Potato", "Salt", "Vegetable Oil" };

        /// <summary>
        /// Creates a default side with the small size
        /// </summary>
        public Fryceritops()
        {
            this.Size = Size.Small;
        }

        /// <summary>
        /// Sets the side's Size. Adjusts the Price and Calories accordingly.
        /// </summary>
        public override Size Size {
            get => size;
            set {
                size = value;
                switch (size)
                {
                    case Size.Small:
                        Price = .99;
                        Calories = 222;
                        break;
                    case Size.Medium:
                        Price = 1.45;
                        Calories = 365;
                        break;
                    case Size.Large:
                        Price = 1.95;
                        Calories = 480;
                        break;
                }
            }
        }
    }
}
