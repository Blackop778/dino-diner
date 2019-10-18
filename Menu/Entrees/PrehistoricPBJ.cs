/* PrehistoricPBJ.cs
 * Author: Nathan Bean
 * Modified by: Nathan Faltermeier
 */

using System.Collections.Generic;

namespace DinoDiner.Menu
{
    /// <summary>
    /// The prehistoric pbj entree
    /// </summary>
    public class PrehistoricPBJ : Entree
    {
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool peanutButter = true;
        /// <summary>
        /// Whether or not the ingredient is included in the entree
        /// </summary>
        private bool jelly = true;

        /// <summary>
        /// The ingredients in the entree with the current holdings
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>() { "Bread" };
                if (peanutButter) ingredients.Add("Peanut Butter");
                if (jelly) ingredients.Add("Jelly");
                return ingredients;
            }
        }

        /// <summary>
        /// Creates a default Prehistoric PBJ
        /// </summary>
        public PrehistoricPBJ()
        {
            this.Price = 6.52;
            this.Calories = 483;
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldPeanutButter()
        {
            this.peanutButter = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Removes the ingredient from the entree
        /// </summary>
        public void HoldJelly()
        {
            this.jelly = false;
            NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "Prehistoric PB&J";
        }

        /// <summary>
        /// Special instructions for order item
        /// </summary>
        public override string[] Special
        {
            get
            {
                List<string> list = new List<string>();
                if (!peanutButter) list.Add("Hold Peanut Butter");
                if (!jelly) list.Add("Hold Jelly");
                return list.ToArray();
            }
        }
    }
}
