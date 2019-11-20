/* Menu.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Lists all of the items available on the menu
    /// </summary>
    public class Menu
    {
        // backing variable
        private HashSet<string> possibleIngredients;

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

            AddItem(new CretaceousCombo(new Brontowurst()));
            AddItem(new CretaceousCombo(new DinoNuggets()));
            AddItem(new CretaceousCombo(new PrehistoricPBJ()));
            AddItem(new CretaceousCombo(new PterodactylWings()));
            AddItem(new CretaceousCombo(new SteakosaurusBurger()));
            AddItem(new CretaceousCombo(new TRexKingBurger()));
            AddItem(new CretaceousCombo(new VelociWrap()));
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

        public HashSet<string> PossibleIngredients
        {
            get
            {
                if (possibleIngredients == null)
                    possibleIngredients = ComputePossibleIngredients();

                return possibleIngredients;
            }
        }

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

        protected HashSet<string> ComputePossibleIngredients()
        {
            HashSet<string> set = new HashSet<string>();

            foreach (IMenuItem menuItem in AvalibleMenuItems)
            {
                foreach (string ingredient in menuItem.Ingredients)
                {
                    set.Add(ingredient);
                }
            }

            return set;
        }

        /// <summary>
        /// Filters the currently available menu items to only items within the given categories
        /// </summary>
        public void FilterCategories(List<string> categories)
        {
            bool combos = categories.Contains("Combo");
            bool entrees = categories.Contains("Entree");
            bool sides = categories.Contains("Side");
            bool drinks = categories.Contains("Drink");

            for (int i = 0; i < AvalibleMenuItems.Count; i += 1)
            {
                IMenuItem menuItem = AvalibleMenuItems[i];
                // If the item is not in one of the included categories remove it
                if (!(combos && menuItem is CretaceousCombo) &&
                    !(entrees && menuItem is Entree) &&
                    !(sides && menuItem is Side) &&
                    !(drinks &&menuItem is Drink))
                {
                    RemoveItem(menuItem);
                    i -= 1;
                }
            }
        }

        /// <summary>
        /// Filters the currently available menu items to only ones containing the given string
        /// </summary>
        public void FilterNames(string toInclude)
        {
            for (int i = 0; i < AvalibleMenuItems.Count; i += 1)
            {
                IMenuItem menuItem = AvalibleMenuItems[i];
                // if it doesn't contain the toInclude string
                if (menuItem.ToString().IndexOf(toInclude, StringComparison.OrdinalIgnoreCase) == -1) {
                    RemoveItem(menuItem);
                    i -= 1;
                }
            }
        }

        /// <summary>
        /// Filters the currently available menu items to only ones inside the given price bounds (inclusive)
        /// </summary>
        public void FilterPrices(float? min, float? max)
        {
            for (int i = 0; i < AvalibleMenuItems.Count; i += 1)
            {
                IMenuItem menuItem = AvalibleMenuItems[i];
                if ((min != null && menuItem.Price < min) || (max != null && menuItem.Price > max))
                {
                    RemoveItem(menuItem);
                    i -= 1;
                }
            }
        }

        /// <summary>
        /// Filters the currently available menu items to only ones that include none of the excluded ingredients
        /// </summary>
        public void FilterIngredients(List<string> excludedIngredients)
        {
            for (int i = 0; i < AvalibleMenuItems.Count; i += 1)
            {
                IMenuItem menuItem = AvalibleMenuItems[i];
                // If the intersection of the item's ingredients and the banned ingredients is not empty
                if (menuItem.Ingredients.Intersect(excludedIngredients).Any())
                {
                    RemoveItem(menuItem);
                    i -= 1;
                }
            }
        }
    }
}
