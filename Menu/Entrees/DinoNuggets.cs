/* DinoNuggets.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoDiner.Menu.Entrees
{
    public class DinoNuggets : AbstractEntree
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
        }
    }
}
