/* Fryceritops.cs
 * By: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The Triceritots side class
    /// </summary>
    public class Triceritots : Side
    {
        /// <summary>
        /// The ingredients in the side
        /// </summary>
        public override List<string> Ingredients => new List<string>() { "Potato", "Salt", "Vegetable Oil" };

        /// <summary>
        /// Creates a default side with the small size
        /// </summary>
        public Triceritots()
        {
            
        }

        /// <summary>
        /// Sets the side's Size. Adjusts the Price and Calories accordingly.
        /// </summary>
        public override Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                switch (base.Size)
                {
                    case Size.Small:
                        Price = .99;
                        Calories = 352;
                        break;
                    case Size.Medium:
                        Price = 1.45;
                        Calories = 410;
                        break;
                    case Size.Large:
                        Price = 1.95;
                        Calories = 590;
                        break;
                }
                
            }
        }

        /// <summary>
        /// The side's basename with no additional words
        /// </summary>
        /// <returns>The side's basename with no additional words</returns>
        public override string BaseName()
        {
            return "Triceritots";
        }
    }
}
