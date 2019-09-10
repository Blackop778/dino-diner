/* DinoNuggets.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoDiner.Menu.Entrees
{
    public class DinoNuggets : AbstractMenuItem
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

        public override double Price
        {
            get => 4.25 + (.25 * (nuggets - 6));
        }

        public override uint Calories => 59 * nuggets;

        /// <summary>
        /// Creates a default Dino Nuggets entree
        /// </summary>
        public DinoNuggets()
        {
            nuggets = 6;
        }

        /// <summary>
        /// Adds a nugget to the entree
        /// </summary>
        public void AddNugget()
        {
            nuggets += 1;
        }
    }
}
