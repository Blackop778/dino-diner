/* Tyrannotea.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Tea. Comes with ice by default for whatever reason.
    /// </summary>
    public class Tyrannotea : Drink
    {
        // backing variable
        private bool sweet;
        private bool lemon;

        /// <summary>
        /// Creates a tea with ice, but no lemon or sweet
        /// </summary>
        public Tyrannotea()
        {
            Lemon = false;
            Sweet = false;
        }

        /// <summary>
        /// The drink's ingredients
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>() { "Water", "Tea" };
                if (Lemon) ingredients.Add("Lemon");
                if (Sweet) ingredients.Add("Cane Sugar");
                return ingredients;
            }
        }

        /// <summary>
        /// Sets the drink's Size. Adjusts the Price and Calories accordingly.
        /// </summary>
        public override Size Size
        {
            get => size;
            set
            {
                size = value;
                switch (size)
                {
                    case Size.Small:
                        Price = .99;
                        break;
                    case Size.Medium:
                        Price = 1.49;
                        break;
                    case Size.Large:
                        Price = 1.99;
                        break;
                }
                Calories = CalculateCalories();
                OnPropertyChanged("Size");
            }
        }

        /// <summary>
        /// Whether or not this is sweet tea. Sweet tea has twice as many calories.
        /// </summary>
        public bool Sweet
        {
            get => sweet;
            set
            {
                sweet = value;
                Calories = CalculateCalories();
                OnPropertyChanged("Sweet");
            }
        }

        /// <summary>
        /// Whether or not this tea has a lemon
        /// </summary>
        public bool Lemon {
            get => lemon;
            set { lemon = value; OnPropertyChanged("Lemon"); }
        }

        /// <summary>
        /// Calculates the drink's calories based on it's size and sweet status
        /// </summary>
        /// <returns></returns>
        private uint CalculateCalories()
        {
            uint calories = 0;
            switch (Size)
            {
                case Size.Small:
                    calories = 8;
                    break;
                case Size.Medium:
                    calories = 16;
                    break;
                case Size.Large:
                    calories = 32;
                    break;
            }

            if (Sweet)
                calories *= 2;

            return calories;
        }

        /// <summary>
        /// Adds a lemon to the drink. There is no going back.
        /// </summary>
        public void AddLemon()
        {
            Lemon = true;
        }

        /// <summary>
        /// The drink's basename with no additional words
        /// </summary>
        /// <returns>The drink's basename with no additional words</returns>
        public override string BaseName()
        {
            return "Tyrannotea";
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return $"{Size} {(Sweet ? "Sweet " : "")}{BaseName()}";
        }
    }
}
