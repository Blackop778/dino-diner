
using DinoDiner.Menu;
using Xunit;

namespace MenuTest.Drinks
{
    public class SodasaurusTest
    {
        [Fact]
        public void ShouldHaveCorrectDefaultPrice()
        {
            Sodasaurus s = new Sodasaurus();
            Assert.Equal(1.5, s.Price);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultCalories()
        {
            Sodasaurus s = new Sodasaurus();
            Assert.Equal<uint>(112, s.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultIngredients()
        {
            Sodasaurus s = new Sodasaurus();
            Assert.Contains("Water", s.Ingredients);
            Assert.Contains("Natural Flavors", s.Ingredients);
            Assert.Contains("Cane Sugar", s.Ingredients);
            Assert.Equal(3, s.Ingredients.Count);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultIce()
        {
            Sodasaurus s = new Sodasaurus();
            Assert.True(s.Ice);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultSize()
        {
            Sodasaurus s = new Sodasaurus();
            Assert.Equal(Size.Small, s.Size);
        }

        [Fact]
        public void ShouldHaveCorrectCaloriesAndPriceAfterSize()
        {
            Sodasaurus s = new Sodasaurus();
            s.Size = Size.Medium;
            s.Size = Size.Small;
            Assert.Equal(1.5, s.Price);
            Assert.Equal<uint>(112, s.Calories);

            s.Size = Size.Medium;
            Assert.Equal(2, s.Price);
            Assert.Equal<uint>(156, s.Calories);

            s.Size = Size.Large;
            Assert.Equal(2.5, s.Price);
            Assert.Equal<uint>(208, s.Calories);
        }

        [Fact]
        public void ShouldHoldIce()
        {
            Sodasaurus s = new Sodasaurus();
            s.HoldIce();
            Assert.False(s.Ice);
            Assert.Contains("Hold Ice", s.Special);
            Assert.Single(s.Special);
        }

        [Fact]
        public void ShouldSetFlavor()
        {
            Sodasaurus s = new Sodasaurus();
            foreach (SodasaurusFlavor flavor in System.Enum.GetValues(typeof(SodasaurusFlavor)))
            {
                s.Flavor = flavor;
                Assert.Equal(flavor, s.Flavor);
            }
        }
    }
}
