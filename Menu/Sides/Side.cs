using System;
using System.Collections.Generic;
using System.Text;

namespace DinoDiner.Menu.Sides
{

    public enum Size
    {
        Small,
        Medium, 
        Large
    }

    public abstract class Side : AbstractMenuItem
    {
        // Backing variable
        protected Size size;

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        public abstract Size Size { get; set; }

    }
}
