using System;
using System.Collections.Generic;
using System.Text;
using DinoDiner.Menu.Sides;

namespace DinoDiner.Menu.Drinks
{
    public abstract class AbstractDrink : Side
    {
        public bool Ice { get; protected set; }

        public AbstractDrink(bool ice)
        {
            Ice = ice;
        }

        public void HoldIce()
        {
            Ice = false;
        }
    }
}
