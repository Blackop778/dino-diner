/* CretaciousCombo.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Comes with an entree, side, and a drink. Combined price is discounted $0.25.
    /// </summary>
    public class CretaceousCombo : AbstractSizedMenuItem
    {
        /// <summary>
        /// The combo's entree item
        /// </summary>
        public Entree Entree { get; set; }
        /// <summary>
        /// The combo's side item
        /// </summary>
        public Side Side { get; set; } = new MeteorMacAndCheese();
        /// <summary>
        /// The combo's drink
        /// </summary>
        public Drink Drink { get; set; } = new Sodasaurus();
        /// <summary>
        /// The combo's toy
        /// </summary>
        public Toy Toy { get; protected set; }

        /// <summary>
        /// The ingredients of the combo's items
        /// </summary>
        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = Entree.Ingredients;
                ingredients.AddRange(Side.Ingredients);
                ingredients.AddRange(Drink.Ingredients);
                return ingredients;
            }
        }

        /// <summary>
        /// The sum of the combo's item's calories
        /// </summary>
        public override uint Calories { get => Entree.Calories + Side.Calories + Drink.Calories; }

        /// <summary>
        /// The sum of the combo's item's prices with a $0.25 discount
        /// </summary>
        public override double Price { get => Entree.Price + Side.Price + Drink.Price - 0.25; }

        /// <summary>
        /// The size of the combo. Sets the side and drink's sizes.
        /// </summary>
        public override Size Size {
            get => size;
            set
            {
                Side.Size = value;
                Drink.Size = value;
                size = value;
            }
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return $"{Entree} Combo";
        }

        /// <summary>
        /// Creates a combo with the given entree
        /// </summary>
        /// <param name="entree">The combo's entree</param>
        public CretaceousCombo(Entree entree)
        {
            Entree = entree;
        }
    }
}
