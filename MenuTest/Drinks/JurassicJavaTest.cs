using DinoDiner.Menu.Drinks;
using DinoDiner.Menu;
using Xunit;

namespace MenuTest.Drinks
{
    public class JurassicJavaTest
    {
        [Fact]
        public void ShouldHaveCorrectDefaultPrice()
        {
            JurassicJava j = new JurassicJava();
            Assert.Equal(.59, j.Price);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultCalories()
        {
            JurassicJava j = new JurassicJava();
            Assert.Equal<uint>(2, j.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultIngredients()
        {
            JurassicJava j = new JurassicJava();
            Assert.Contains("Water", j.Ingredients);
            Assert.Contains("Coffee", j.Ingredients);
            Assert.Equal(2, j.Ingredients.Count);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultRoomForCream()
        {
            JurassicJava j = new JurassicJava();
            Assert.False(j.RoomForCream);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultIce()
        {
            JurassicJava j = new JurassicJava();
            Assert.False(j.Ice);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultSize()
        {
            JurassicJava j = new JurassicJava();
            Assert.Equal(Size.Small, j.Size);
        }

        [Fact]
        public void ShouldHaveCorrectCaloriesAndPriceAfterSize()
        {
            JurassicJava j = new JurassicJava();
            j.Size = Size.Medium;
            j.Size = Size.Small;
            Assert.Equal(.59, j.Price);
            Assert.Equal<uint>(2, j.Calories);

            j.Size = Size.Medium;
            Assert.Equal(.99, j.Price);
            Assert.Equal<uint>(4, j.Calories);

            j.Size = Size.Large;
            Assert.Equal(1.49, j.Price);
            Assert.Equal<uint>(8, j.Calories);
        }

        [Fact]
        public void ShouldAddIce()
        {
            JurassicJava j = new JurassicJava();
            j.AddIce();
            Assert.True(j.Ice);
        }

        [Fact]
        public void ShouldAddAndRemoveIce()
        {
            JurassicJava j = new JurassicJava();
            j.AddIce();
            j.HoldIce();
            Assert.False(j.Ice);
        }

        [Fact]
        public void ShouldLeaveRoomForCream()
        {
            JurassicJava j = new JurassicJava();
            j.LeaveRoomForCream();
            Assert.True(j.RoomForCream);
        }
    }
}
