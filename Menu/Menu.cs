/* Menu.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Lists all of the items available on the menu
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Creates a menu with all of the default menu items
        /// </summary>
        public Menu()
        {
            AvalibleMenuItems = new List<IMenuItem>();
            AvalibleEntrees = new List<Entree>();
            AvailableSides = new List<Side>();
            AvailableDrinks = new List<Drink>();
            AvailableCombos = new List<CretaceousCombo>();

            AddItem(new Brontowurst());
            AddItem(new DinoNuggets());
            AddItem(new PrehistoricPBJ());
            AddItem(new PterodactylWings());
            AddItem(new SteakosaurusBurger());
            AddItem(new TRexKingBurger());
            AddItem(new VelociWrap());

            AddItem(new Fryceritops());
            AddItem(new MeteorMacAndCheese());
            AddItem(new MezzorellaSticks());
            AddItem(new Triceritots());

            AddItem(new JurassicJava());
            AddItem(new Sodasaurus());
            AddItem(new Tyrannotea());
            AddItem(new Water());
        }

        /// <summary>
        /// All available menu items
        /// </summary>
        public List<IMenuItem> AvalibleMenuItems { get; protected set; }

        /// <summary>
        /// All available entrees
        /// </summary>
        public List<Entree> AvalibleEntrees { get; protected set; }

        /// <summary>
        /// All available sides
        /// </summary>
        public List<Side> AvailableSides { get; protected set; }

        /// <summary>
        /// All available drinks
        /// </summary>
        public List<Drink> AvailableDrinks { get; protected set; }

        /// <summary>
        /// All available combos
        /// </summary>
        public List<CretaceousCombo> AvailableCombos { get; protected set; }

        /// <summary>
        /// Adds a menu item to the appropriate lists
        /// </summary>
        /// <param name="item">The item to add</param>
        public void AddItem(IMenuItem item)
        {
            AvalibleMenuItems.Add(item);

            if (item is Entree e)
                AvalibleEntrees.Add(e);
            else if (item is Side s)
                AvailableSides.Add(s);
            else if (item is Drink d)
                AvailableDrinks.Add(d);
            else if (item is CretaceousCombo c)
                AvailableCombos.Add(c);
        }

        /// <summary>
        /// Removes a menu item from the appropriate lists
        /// </summary>
        /// <param name="item">The item to remove</param>
        public void RemoveItem(IMenuItem item)
        {
            AvalibleMenuItems.Remove(item);

            if (item is Entree e)
                AvalibleEntrees.Remove(e);
            else if (item is Side s)
                AvailableSides.Remove(s);
            else if (item is Drink d)
                AvailableDrinks.Remove(d);
            else if (item is CretaceousCombo c)
                AvailableCombos.Remove(c);
        }

        /// <summary>
        /// A list of all available menu items, one item per line.
        /// </summary>
        /// <returns>A list of all available menu items, one item per line.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IMenuItem i in AvalibleMenuItems)
            {
                sb.Append(i).Append("\n");
            }

            // Remove last new line
            if (sb.Length >= 2)
                sb.Length -= 2;

            return sb.ToString();
        }
    }
}
