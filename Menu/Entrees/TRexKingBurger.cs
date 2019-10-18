/* TRexKingBurger.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The T-Rex King Burger entree
    /// </summary>
    public class TRexKingBurger : Entree
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
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldLettuce()
        {
            this.lettuce = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldTomato()
        {
            this.tomatoes = false;
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
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldPickle()
        {
            this.pickles = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldKetchup()
        {
            this.ketchup = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldMustard()
        {
            this.mustard = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldMayo()
        {
            this.mayo = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "T-Rex King Burger";
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
                if (!lettuce) special.Add("Hold Lettuce");
                if (!tomatoes) special.Add("Hold Tomato");
                if (!onions) special.Add("Hold Onion");
                if (!pickles) special.Add("Hold Pickle");
                if (!ketchup) special.Add("Hold Ketchup");
                if (!mustard) special.Add("Hold Mustard");
                if (!mayo) special.Add("Hold Mayo");
                return special.ToArray();
            }
        }
    }
}
