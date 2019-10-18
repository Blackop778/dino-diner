/* Side.cs
 * Author: Nathan Faltermeier
 */

namespace DinoDiner.Menu
{
    /// <summary>
    /// Represents a side item. Comes in multiple sizes.
    /// </summary>
    public abstract class Side : AbstractSizedMenuItem
    {
        /// <summary>
        /// The side's basename with no additional words
        /// </summary>
        /// <returns>The side's basename with no additional words</returns>
        public abstract string BaseName();

        /// <summary>
        /// Returns the side's size followed by it's basename
        /// </summary>
        /// <returns>the side's size followed by it's basename</returns>
        public override string ToString()
        {
            return $"{Size} {BaseName()}";
        }

        public override string[] Special => new string[] { };
    }
}
