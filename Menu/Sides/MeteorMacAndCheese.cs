using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu.Sides
{
    public class MeteorMacAndCheese : Side
    {
        public override List<string> Ingredients => new List<string>() { "Macaroni Noodles", "Cheese Product", "Pork Sausage" };

        public MeteorMacAndCheese()
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
                        Calories = 420;
                        break;
                    case Size.Medium:
                        Price = 1.45;
                        Calories = 490;
                        break;
                    case Size.Large:
                        Price = 1.95;
                        Calories = 520;
                        break;
                }
            }
        }
    }
}
