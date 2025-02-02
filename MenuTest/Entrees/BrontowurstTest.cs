using System.Collections.Generic;
using Xunit;
using DinoDiner.Menu;


namespace MenuTest.Entrees
{
    public class BrontowurstUnitTest
    {
        [Fact]
        public void ShouldHaveCorrectDefaultPrice()
        {
            Brontowurst bw = new Brontowurst();
            Assert.Equal(5.36, bw.Price, 2);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultCalories()
        {
            Brontowurst bw = new Brontowurst();
            Assert.Equal<uint>(498, bw.Calories);
        }

        [Fact]
        public void ShouldListDefaultIngredients()
        {
            Brontowurst bw = new Brontowurst();
            List<string> ingredients = bw.Ingredients;
            Assert.Contains<string>("Whole Wheat Bun", ingredients);
            Assert.Contains<string>("Brautwurst", ingredients);
            Assert.Contains<string>("Peppers", ingredients);
            Assert.Contains<string>("Onion", ingredients);
            Assert.Equal<int>(4, ingredients.Count);
        }

        [Fact]
        public void HoldBunShouldRemoveBun()
        {
            Brontowurst bw = new Brontowurst();
            bw.HoldBun();
            Assert.DoesNotContain<string>("Whole Wheat Bun", bw.Ingredients);
            Assert.Contains("Hold Bun", bw.Special);
            Assert.Single(bw.Special);
        }

        [Fact]
        public void HoldPeppersShouldRemovePeppers()
        {
            Brontowurst bw = new Brontowurst();
            bw.HoldPeppers();
            Assert.DoesNotContain<string>("Peppers", bw.Ingredients);
            Assert.Contains("Hold Peppers", bw.Special);
            Assert.Single(bw.Special);
        }

        [Fact]
        public void HoldOnionShouldRemoveOnion()
        {
            Brontowurst bw = new Brontowurst();
            bw.HoldOnion();
            Assert.DoesNotContain<string>("Onion", bw.Ingredients);
            Assert.Contains("Hold Onion", bw.Special);
            Assert.Single(bw.Special);
        }

        [Fact]
        public void ShouldCombineSpecialInstructions()
        {
            Brontowurst b = new Brontowurst();

            b.HoldBun();
            b.HoldOnion();
            b.HoldPeppers();

            Assert.Contains("Hold Bun", b.Special);
            Assert.Contains("Hold Onion", b.Special);
            Assert.Contains("Hold Peppers", b.Special);
            Assert.Equal(3, b.Special.Length);
        }
    }

}
