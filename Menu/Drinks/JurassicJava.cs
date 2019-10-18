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
    public class JurassicJava : Drink
    {
        // backing variables
        private bool decaf;
        private bool roomForCream;

        /// <summary>
        /// The drink's ingredients
        /// </summary>
        public override List<string> Ingredients => new List<string>() { "Water", "Coffee" };

        /// <summary>
        /// Sets the drink's Size. Adjusts the Price and Calories accordingly.
        /// </summary>
        public override Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                switch (base.Size)
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
        /// Whether or not the coffee is decaf
        /// </summary>
        public bool Decaf {
            get => decaf;
            set { decaf = value; NotifyPropertyChanged("Decaf"); NotifyPropertyChanged("Description"); }
        }

        /// <summary>
        /// Whether or not the drink has room for cream
        /// </summary>
        public bool RoomForCream {
            get => roomForCream;
            set { roomForCream = value; NotifyPropertyChanged("RoomForCream"); NotifyPropertyChanged("Special"); }
        }

        /// <summary>
        /// Coffee does not come with ice by default
        /// </summary>
        public override bool IceByDefault => false;

        /// <summary>
        /// Creates a JurassicJava with no ice or room for cream
        /// </summary>
        public JurassicJava()
        {
            RoomForCream = false;
            Decaf = false;
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
        /// The drink's basename with no additional words
        /// </summary>
        /// <returns>The drink's basename with no additional words</returns>
        public override string BaseName()
        {
            return "Jurassic Java";
        }

        /// <summary>
        /// The item's name
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return $"{Size} {(Decaf ? "Decaf " : "")}{BaseName()}";
        }

        /// <summary>
        /// Special instructions for the order item
        /// </summary>
        public override string[] Special
        {
            get
            {
                List<string> list = SpecialList;
                if (RoomForCream) list.Add("Add Room For Cream");
                return list.ToArray();
            }
        }
    }
}
