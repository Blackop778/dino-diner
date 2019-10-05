/* PterodactylWings.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The pterodactyl wings entree
    /// </summary>
    public class PterodactylWings : Entree
    {
        /// <summary>
        /// The ingredients in the entree
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                return new List<string>() { "Chicken", "Wing Sauce" };
            }
        }

        /// <summary>
        /// Creates a default pterodactyl wings entree
        /// </summary>
        public PterodactylWings()
        {
            this.Price = 7.21;
            this.Calories = 318;
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "Pterodactyl Wings";
        }
    }
}
