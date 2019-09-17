using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu.Sides
{
    public class Triceritots : Side
    {
        public override List<string> Ingredients => new List<string>() { "Potato", "Salt", "Vegetable Oil" };

        public Triceritots()
        {
            this.Size = Size.Small;
        }

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
                        Calories = 352;
                        break;
                    case Size.Medium:
                        Price = 1.45;
                        Calories = 410;
                        break;
                    case Size.Large:
                        Price = 1.95;
                        Calories = 590;
                        break;
                }
            }
        }
    }
}
