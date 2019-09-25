﻿/* Sodasaurus.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu.Drinks
{
    /// <summary>
    /// The possible flavors for Sodasaurus
    /// </summary>
    public enum SodasaurusFlavor
    {
        Cola,
        Orange,
        Vanilla,
        Chocolate,
        RootBeer,
        Cherry,
        Lime
    };

    /// <summary>
    /// A multi-flavored soda
    /// </summary>
    public class Sodasaurus : AbstractDrink
    {
        /// <summary>
        /// Creates a Soda with the given flavor and ice
        /// </summary>
        /// <param name="flavor"></param>
        public Sodasaurus(SodasaurusFlavor flavor) : base(true)
        {
            Flavor = flavor;
        }

        /// <summary>
        /// The drink's ingredients
        /// </summary>
        public override List<string> Ingredients => new List<string>() { "Water", "Natural Flavors", "Cane Sugar" };

        /// <summary>
        /// Sets the drink's Size. Adjusts the Price and Calories accordingly.
        /// </summary>
        public override Size Size
        {
            get => size;
            set
            {
                size = value;
                switch (size)
                {
                    case Size.Small:
                        Price = 1.5;
                        Calories = 112;
                        break;
                    case Size.Medium:
                        Price = 2;
                        Calories = 156;
                        break;
                    case Size.Large:
                        Price = 2.5;
                        Calories = 208;
                        break;
                }
            }
        }

        /// <summary>
        /// The drink's flavor
        /// </summary>
        public SodasaurusFlavor Flavor { get; set; }
    }
}
