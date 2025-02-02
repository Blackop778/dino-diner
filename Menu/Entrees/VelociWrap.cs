﻿/* VelociWrap.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The velociwrap entree
    /// </summary>
    public class VelociWrap : Entree
    {
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool dressing = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool lettuce = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool cheese = true;

        /// <summary>
        /// The ingredients in the entree with the current holdings
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>() { "Flour Tortilla", "Chicken Breast" };
                if (dressing) ingredients.Add("Ceasar Dressing");
                if (lettuce) ingredients.Add("Romaine Lettuce");
                if (cheese) ingredients.Add("Parmesan Cheese");
                return ingredients;
            }
        }

        /// <summary>
        /// Creates a default Veloci-wrap
        /// </summary>
        public VelociWrap()
        {
            this.Price = 6.86;
            this.Calories = 356;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldDressing()
        {
            this.dressing = false;
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
        public void HoldCheese()
        {
            this.cheese = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "Veloci-Wrap";
        }

        /// <summary>
        /// Special Instructions for the order
        /// </summary>
        public override string[] Special
        {
            get
            {
                List<string> special = new List<string>();
                if (!dressing) special.Add("Hold Dressing");
                if (!lettuce) special.Add("Hold Lettuce");
                if (!cheese) special.Add("Hold Cheese");
                return special.ToArray();
            }
        }
    }
}
