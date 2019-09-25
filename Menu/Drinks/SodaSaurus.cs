using System;
using System.Collections.Generic;
using System.Text;
using DinoDiner.Menu.Sides;

namespace DinoDiner.Menu.Drinks
{
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

    public class Sodasaurus : AbstractDrink
    {
        public Sodasaurus(SodasaurusFlavor flavor) : base(true)
        {
            Flavor = flavor;
        }

        public override List<string> Ingredients => new List<string>() { "Water", "Natural Flavors", "Cane Sugar" };

        /// <summary>
        /// Sets the side's Size. Adjusts the Price and Calories accordingly.
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

        public SodasaurusFlavor Flavor { get; set; }
    }
}
