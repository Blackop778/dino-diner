using System;
using System.Collections.Generic;
using System.Text;
using DinoDiner.Menu.Sides;

namespace DinoDiner.Menu.Drinks
{
    public class JurassicJava : AbstractDrink
    {
        public override List<string> Ingredients => new List<string>() { "Water", "Coffee" };

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
                        Price = .59;
                        Calories = 2;
                        break;
                    case Size.Medium:
                        Price = .99;
                        Calories = 4;
                        break;
                    case Size.Large:
                        Price = 1.49;
                        Calories = 8;
                        break;
                }
            }
        }

        public bool RoomForCream { get; protected set; }

        public JurassicJava() : base(false)
        {
            RoomForCream = false;
        }

        public void AddIce()
        {
            Ice = true;
        }

        public void LeaveRoomForCream()
        {
            RoomForCream = true;
        }
    }
}
