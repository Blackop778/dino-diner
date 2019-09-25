using System;
using System.Collections.Generic;
using System.Text;
using DinoDiner.Menu.Sides;

namespace DinoDiner.Menu.Drinks
{
    public class Tyrannotea : AbstractDrink
    {
        protected bool sweet;

        public Tyrannotea() : base(true)
        {
            Lemon = false;
            Sweet = false;
        }

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
        /// Sets the side's Size. Adjusts the Price and Calories accordingly.
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
            }
        }

        public bool Sweet
        {
            get => sweet;
            set
            {
                sweet = value;
                Calories = CalculateCalories();
            }
        }

        public bool Lemon { get; protected set; }

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

        public void AddLemon()
        {
            Lemon = true;
        }
    }
}
