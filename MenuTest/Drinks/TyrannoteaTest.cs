
using DinoDiner.Menu;
using Xunit;

namespace MenuTest.Drinks
{
    public class TyrannoteaTest
    {
        [Fact]
        public void ShouldHaveCorrectDefaultPrice()
        {
            Tyrannotea t = new Tyrannotea();
            Assert.Equal(.99, t.Price);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultCalories()
        {
            Tyrannotea t = new Tyrannotea();
            Assert.Equal<uint>(8, t.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultIngredients()
        {
            Tyrannotea t = new Tyrannotea();
            Assert.Contains("Water", t.Ingredients);
            Assert.Contains("Tea", t.Ingredients);
            Assert.Equal(2, t.Ingredients.Count);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultIce()
        {
            Tyrannotea t = new Tyrannotea();
            Assert.True(t.Ice);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultLemon()
        {
            Tyrannotea t = new Tyrannotea();
            Assert.False(t.Lemon);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultSweet()
        {
            Tyrannotea t = new Tyrannotea();
            Assert.False(t.Sweet);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultSize()
        {
            Tyrannotea t = new Tyrannotea();
            Assert.Equal(Size.Small, t.Size);
        }

        [Fact]
        public void ShouldHaveCorrectCaloriesAndPriceAfterSize()
        {
            Tyrannotea t = new Tyrannotea();
            t.Size = Size.Medium;
            t.Size = Size.Small;
            Assert.Equal(.99, t.Price);
            Assert.Equal<uint>(8, t.Calories);

            t.Size = Size.Medium;
            Assert.Equal(1.49, t.Price);
            Assert.Equal<uint>(16, t.Calories);

            t.Size = Size.Large;
            Assert.Equal(1.99, t.Price);
            Assert.Equal<uint>(32, t.Calories);
        }

        [Fact]
        public void ShouldHoldIce()
        {
            Tyrannotea t = new Tyrannotea();
            t.HoldIce();
            Assert.False(t.Ice);
            Assert.Contains("Hold Ice", t.Special);
            Assert.Single(t.Special);
        }

        [Fact]
        public void ShouldAddLemon()
        {
            Tyrannotea t = new Tyrannotea();
            t.AddLemon();
            Assert.True(t.Lemon);
            Assert.Contains("Water", t.Ingredients);
            Assert.Contains("Tea", t.Ingredients);
            Assert.Contains("Lemon", t.Ingredients);
            Assert.Equal(3, t.Ingredients.Count);
            Assert.Contains("Add Lemon", t.Special);
            Assert.Single(t.Special);
        }

        [Fact]
        public void ShouldHaveCorrectCaloriesAfterSizeAndSweet()
        {
            Tyrannotea t = new Tyrannotea();
            t.Sweet = true;
            Assert.Equal<uint>(16, t.Calories);

            t.Sweet = false;
            Assert.Equal<uint>(8, t.Calories);

            t.Size = Size.Medium;
            t.Sweet = true;
            Assert.Equal<uint>(32, t.Calories);

            t.Sweet = false;
            Assert.Equal<uint>(16, t.Calories);

            t.Size = Size.Large;
            t.Sweet = true;
            Assert.Equal<uint>(64, t.Calories);

            t.Sweet = false;
            Assert.Equal<uint>(32, t.Calories);
        }

        [Fact]
        public void ShouldCombineSpecialInstructions()
        {
            Tyrannotea t = new Tyrannotea();

            t.AddLemon();
            t.HoldIce();

            Assert.Contains("Add Lemon", t.Special);
            Assert.Contains("Hold Ice", t.Special);
            Assert.Equal(2, t.Special.Length);
        }
    }
}
