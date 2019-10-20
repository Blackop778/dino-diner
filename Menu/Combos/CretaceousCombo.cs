/* CretaciousCombo.cs
 * Author: Nathan Faltermeier
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DinoDiner.Menu
{
    /// <summary>
    /// Comes with an entree, side, and a drink. Combined price is discounted $0.25.
    /// </summary>
    public class CretaceousCombo : AbstractSizedMenuItem
    {
        //backing variables
        private Entree entree;
        private Side side;
        private Drink drink;

        /// <summary>
        /// The combo's entree item
        /// </summary>
        public Entree Entree
        {
            get => entree;
            set {
                if (entree != null) entree.PropertyChanged -= OnItemPropertyChanged;
                entree = value;
                if (entree != null) entree.PropertyChanged += OnItemPropertyChanged;
                NotifyPropertyChanged("Entree");
                NotifyPropertyChanged("Special");
                NotifyPropertyChanged("Description");
            }
        }
        /// <summary>
        /// The combo's side item
        /// </summary>
        public Side Side
        {
            get => side;
            set
            {
                if (side != null) side.PropertyChanged -= OnItemPropertyChanged;
                side = value;
                if (side != null) side.PropertyChanged += OnItemPropertyChanged;
                NotifyPropertyChanged("Side");
                NotifyPropertyChanged("Special");
            }
        }
        /// <summary>
        /// The combo's drink
        /// </summary>
        public Drink Drink
        {
            get => drink;
            set
            {
                if (drink != null) drink.PropertyChanged -= OnItemPropertyChanged;
                drink = value;
                if (drink != null) drink.PropertyChanged += OnItemPropertyChanged;
                NotifyPropertyChanged("Drink");
                NotifyPropertyChanged("Special");
            }
        }
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
            get => base.Size;
            set
            {
                // Side and Drink will be null when AbstractSizedMenuItem's constructor is called
                // and tries to set size to Small as Combo constructor hasn't been called by then
                if (Side != null)
                    Side.Size = value;
                if (Drink != null)
                    Drink.Size = value;
                base.Size = value;
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
            Side = new MezzorellaSticks();
            Drink = new Sodasaurus();
            Size = Size.Small;
        }

        /// <summary>
        /// Rebroadcast an Entree, Side, or Drink's property changed event for the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            NotifyPropertyChanged(args.PropertyName);
            // Whatever was changed probably changed the special as well
            if (args.PropertyName != "Special" && args.PropertyName != "Price" && args.PropertyName != "Calories")
                NotifyPropertyChanged("Special");
        }

        /// <summary>
        /// Special Instructions for this item
        /// </summary>
        public override string[] Special
        {
            get
            {
                List<string> special = new List<string>();
                special.AddRange(Entree.Special);
                special.Add(Drink.ToString());
                special.AddRange(Drink.Special);
                special.Add(Side.ToString());
                special.AddRange(Side.Special);
                return special.ToArray();
            }
        }

        /// <summary>
        /// Performs a shallow clone and also clones the combo's entree, drink, and side
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            object ret = base.Clone();

            if (ret is CretaceousCombo c)
            {
                // Ensures that the property changed listeners on the entree, side, and drink refer to the new instance of Combo
                // instead of the one that is being cloned since the property setter resets the listeners
                c.Entree = (Entree) c.Entree.Clone();
                c.Drink = (Drink) c.Drink.Clone();
                c.Side = (Side) c.Side.Clone();
            }

            return ret;
        }
    }
}
