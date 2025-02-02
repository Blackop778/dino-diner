﻿
using DinoDiner.Menu;
using Xunit;

namespace MenuTest.Drinks
{
    public class WaterTest
    {
        [Fact]
        public void ShouldHaveCorrectDefaultPrice()
        {
            Water w = new Water();
            Assert.Equal(.10, w.Price);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultCalories()
        {
            Water w = new Water();
            Assert.Equal<uint>(0, w.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultIngredients()
        {
            Water w = new Water();
            Assert.Contains("Water", w.Ingredients);
            Assert.Single(w.Ingredients);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultLemon()
        {
            Water w = new Water();
            Assert.False(w.Lemon);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultIce()
        {
            Water w = new Water();
            Assert.True(w.Ice);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultSize()
        {
            Water w = new Water();
            Assert.Equal(Size.Small, w.Size);
        }

        [Fact]
        public void ShouldHaveCorrectCaloriesAndPriceAfterSize()
        {
            Water w = new Water();
            w.Size = Size.Medium;
            w.Size = Size.Small;
            Assert.Equal(.10, w.Price);
            Assert.Equal<uint>(0, w.Calories);

            w.Size = Size.Medium;
            Assert.Equal(.10, w.Price);
            Assert.Equal<uint>(0, w.Calories);

            w.Size = Size.Large;
            Assert.Equal(.10, w.Price);
            Assert.Equal<uint>(0, w.Calories);
        }

        [Fact]
        public void ShouldHoldIce()
        {
            Water w = new Water();
            w.HoldIce();
            Assert.False(w.Ice);
            Assert.Contains("Hold Ice", w.Special);
            Assert.Single(w.Special);
        }

        [Fact]
        public void ShouldAddLemon()
        {
            Water w = new Water();
            w.AddLemon();
            Assert.True(w.Lemon);
            Assert.Contains("Water", w.Ingredients);
            Assert.Contains("Lemon", w.Ingredients);
            Assert.Equal(2, w.Ingredients.Count);
            Assert.Contains("Add Lemon", w.Special);
            Assert.Single(w.Special);
        }

        [Fact]
        public void ShouldCombineSpecialInstructions()
        {
            Water w = new Water();

            w.AddLemon();
            w.HoldIce();

            Assert.Contains("Add Lemon", w.Special);
            Assert.Contains("Hold Ice", w.Special);
            Assert.Equal(2, w.Special.Length);
        }
    }
}
