/* DinoNuggets.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The dino nuggets entree
    /// </summary>
    public class DinoNuggets : Entree
    {
        /// <summary>
        /// How many nuggets are in the entree
        /// </summary>
        private uint nuggets;

        /// <summary>
        /// The ingredients in the entree with the current nugget count
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                return Enumerable.Repeat("Chicken Nugget", (int) nuggets).ToList();
            }
        }

        /// <summary>
        /// Creates a default Dino Nuggets entree
        /// </summary>
        public DinoNuggets()
        {
            nuggets = 6;
            this.Price = 4.25;
            this.Calories += 354;
        }

        /// <summary>
        /// Adds a nugget to the entree
        /// </summary>
        public void AddNugget()
        {
            nuggets += 1;
            this.Price += .25;
            this.Calories += 59;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "Dino-Nuggets";
        }

        /// <summary>
        /// Special instructions
        /// </summary>
        public override string[] Special
        {
            get
            {
                if (nuggets == 6)
                    return new string[] { };
                else
                    return new string[] { $"{nuggets - 6} Extra Nuggets" };
            }
        }
    }
}
