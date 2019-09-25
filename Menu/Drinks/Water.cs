using System;
using System.Collections.Generic;
using System.Text;
using DinoDiner.Menu.Sides;

namespace DinoDiner.Menu.Drinks
{
    public class Water : AbstractDrink
    {
        public Water() : base(true)
        {
            Lemon = false;
        }

        public override List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>() { "Water" };
                if (Lemon) ingredients.Add("Lemon");
                return ingredients;
            }
        }

        /// <summary>
        /// Sets the side's Size. Adjusts the Price and Calories accordingly.
        /// </summary>
        public override Size Size
        {
            get => size;
            set
            {
                size = value;
                Price = .10;
                Calories = 0;
            }
        }

        public bool Lemon { get; protected set; }

        public void AddLemon()
        {
            Lemon = true;
        }
    }
}
