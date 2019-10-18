/* Sodasaurus.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
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
    public class Sodasaurus : Drink
    {
        // Backing variable
        private SodasaurusFlavor flavor;
        /// <summary>
        /// Creates a Soda with the given flavor and ice
        /// </summary>
        /// <param name="flavor"></param>
        public Sodasaurus()
        {
            Flavor = SodasaurusFlavor.Cherry;
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
            get => base.Size;
            set
            {
                base.Size = value;
                switch (base.Size)
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
        public SodasaurusFlavor Flavor {
            get => flavor;
            set { flavor = value; NotifyPropertyChanged("Flavor"); NotifyPropertyChanged("Description"); }
        }

        /// <summary>
        /// The drink's basename with no additional words
        /// </summary>
        /// <returns>The drink's basename with no additional words</returns>
        public override string BaseName()
        {
            return "Sodasaurus";
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return $"{Size} {Flavor} {BaseName()}";
        }

        public override string[] Special => SpecialList.ToArray();
    }
}
