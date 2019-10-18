/* Brontowurst.cs
 * Author: Nathan Faltermeier
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Brontowurst Entree
    /// </summary>
    public class Brontowurst : Entree
    {
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool bun = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool peppers = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool onions = true;

        /// <summary>
        /// The ingredients in the entree with the current holdings
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>() { "Brautwurst" };
                if (bun) ingredients.Add("Whole Wheat Bun");
                if (peppers) ingredients.Add("Peppers");
                if (onions) ingredients.Add("Onion");
                return ingredients;
            }
        }

        /// <summary>
        /// Creates a default Brontowurst
        /// </summary>
        public Brontowurst()
        {
            this.Price = 5.36;
            this.Calories = 498;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldBun()
        {
            this.bun = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldPeppers()
        {
            this.peppers = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldOnion()
        {
            this.onions = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "Brontowurst";
        }

        /// <summary>
        /// Special instructions for the order
        /// </summary>
        public override string[] Special
        {
            get
            {
                List<string> special = new List<string>();
                if (!bun) special.Add("Hold Bun");
                if (!peppers) special.Add("Hold Peppers");
                if (!onions) special.Add("Hold Onion");
                return special.ToArray();
            }
        }
    }
}
