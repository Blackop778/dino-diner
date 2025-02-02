﻿/* SteakosaurusBurger.cs
 * Author: Nathan Faltermeier
 */ 

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Steakosaurus Burger Entree
    /// </summary>
    public class SteakosaurusBurger : Entree
    {
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool bun = true;
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
        /// The ingredients in the entree with the current holdings
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>() { "Steakburger Pattie" };
                if (bun) ingredients.Add("Whole Wheat Bun");
                if (pickles) ingredients.Add("Pickle");
                if (ketchup) ingredients.Add("Ketchup");
                if (mustard) ingredients.Add("Mustard");
                return ingredients;
            }
        }

        /// <summary>
        /// Creates a default steakosaurus burger
        /// </summary>
        public SteakosaurusBurger()
        {
            this.Price = 5.15;
            this.Calories = 621;
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
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "Steakosaurus Burger";
        }

        /// <summary>
        /// The special instructions for this item
        /// </summary>
        public override string[] Special
        {
            get
            {
                List<string> list = new List<string>();
                if (!bun) list.Add("Hold Bun");
                if (!pickles) list.Add("Hold Pickle");
                if (!ketchup) list.Add("Hold Ketchup");
                if (!mustard) list.Add("Hold Mustard");
                return list.ToArray();
            }
        }
    }
}
