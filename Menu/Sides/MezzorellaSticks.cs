/* MezzorellaSticks.cs
 * By: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The MezzorellaSticks side class
    /// </summary>
    public class MezzorellaSticks : Side
    {
        /// <summary>
        /// The ingredients in the side
        /// </summary>
        public override List<string> Ingredients => new List<string>() { "Cheese Product", "Breading", "Vegetable Oil" };

        /// <summary>
        /// Creates a default side with the small size
        /// </summary>
        public MezzorellaSticks()
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
                        Calories = 540;
                        break;
                    case Size.Medium:
                        Price = 1.45;
                        Calories = 610;
                        break;
                    case Size.Large:
                        Price = 1.95;
                        Calories = 720;
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
            return "Mezzorella Sticks";
        }
    }
}
