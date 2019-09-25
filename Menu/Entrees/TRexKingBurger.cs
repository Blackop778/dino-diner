/* TRexKingBurger.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu.Entrees
{
    public class TRexKingBurger : AbstractEntree
    {
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool bun = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool lettuce = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool tomatoes = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool onions = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool pickles = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool ketchup = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool mustard = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool mayo = true;

        /// <summary>
        /// The ingredients in the entree with the current holdings
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>() { "Steakburger Pattie", "Steakburger Pattie", "Steakburger Pattie" };
                if (bun) ingredients.Add("Whole Wheat Bun");
                if (lettuce) ingredients.Add("Lettuce");
                if (tomatoes) ingredients.Add("Tomato");
                if (onions) ingredients.Add("Onion");
                if (pickles) ingredients.Add("Pickle");
                if (ketchup) ingredients.Add("Ketchup");
                if (mustard) ingredients.Add("Mustard");
                if (mayo) ingredients.Add("Mayo");
                return ingredients;
            }
        }

        /// <summary>
        /// Creates a default T-Rex king burger
        /// </summary>
        public TRexKingBurger()
        {
            this.Price = 8.45;
            this.Calories = 728;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldBun()
        {
            this.bun = false;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldLettuce()
        {
            this.lettuce = false;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldTomato()
        {
            this.tomatoes = false;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldOnion()
        {
            this.onions = false;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldPickle()
        {
            this.pickles = false;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldKetchup()
        {
            this.ketchup = false;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldMustard()
        {
            this.mustard = false;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldMayo()
        {
            this.mayo = false;
        }
    }
}
