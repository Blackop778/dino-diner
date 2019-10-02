/* JurassicJava.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// JurassicJava. Coffee. No ice or room for cream by default.
    /// </summary>
    public class JurassicJava : AbstractDrink
    {
        /// <summary>
        /// The drink's ingredients
        /// </summary>
        public override List<string> Ingredients => new List<string>() { "Water", "Coffee" };

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

        /// <summary>
        /// Whether or not the drink has room for cream
        /// </summary>
        public bool RoomForCream { get; protected set; }

        /// <summary>
        /// Creates a JurassicJava with no ice or room for cream
        /// </summary>
        public JurassicJava() : base(false)
        {
            RoomForCream = false;
        }

        /// <summary>
        /// Adds ice to the drink
        /// </summary>
        public void AddIce()
        {
            Ice = true;
        }

        /// <summary>
        /// Leaves room for cream
        /// </summary>
        public void LeaveRoomForCream()
        {
            RoomForCream = true;
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return "Jurassic Java";
        }
    }
}
