﻿/* MeteorMacAndCheese.cs
 * By: Nathan Faltermeier
 */
 
using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The MeteorMacAndCheese side class
    /// </summary>
    public class MeteorMacAndCheese : Side
    {
        /// <summary>
        /// The ingredients in the side
        /// </summary>
        public override List<string> Ingredients => new List<string>() { "Macaroni Noodles", "Cheese Product", "Pork Sausage" };

        /// <summary>
        /// Creates a default side with the small size
        /// </summary>
        public MeteorMacAndCheese()
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
                        Calories = 420;
                        break;
                    case Size.Medium:
                        Price = 1.45;
                        Calories = 490;
                        break;
                    case Size.Large:
                        Price = 1.95;
                        Calories = 520;
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
            return "Meteor Mac and Cheese";
        }
    }
}
