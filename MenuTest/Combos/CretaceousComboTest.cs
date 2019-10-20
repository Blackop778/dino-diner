using Xunit;
using DinoDiner.Menu;

namespace MenuTest.Combos
{
    public class CretaceousComboTest
    {
        [Fact]
        public void ShouldHaveCorrectDefaultSpecial()
        {
            CretaceousCombo c = new CretaceousCombo(new PrehistoricPBJ());

            Assert.Contains("Small Mezzorella Sticks", c.Special);
            Assert.Contains("Small Cherry Sodasaurus", c.Special);
            Assert.Equal(2, c.Special.Length);
        }

        [Fact]
        public void ShouldHaveCorrectDescriptionAndSpecialAfterModification()
        {
            CretaceousCombo c = new CretaceousCombo(new PrehistoricPBJ());

            c.Entree = new VelociWrap();
            c.Side = new Triceritots();
            c.Drink = new Tyrannotea();

            Assert.Equal("Veloci-Wrap Combo", c.Description);
            Assert.Contains("Small Triceritots", c.Special);
            Assert.Contains("Small Tyrannotea", c.Special);
            Assert.Equal(2, c.Special.Length);
        }

        [Fact]
        public void ShouldHaveCorrectSpecialAfterHolds()
        {
            CretaceousCombo c = new CretaceousCombo(new PrehistoricPBJ());

            VelociWrap v = new VelociWrap();
            c.Entree = v;
            c.Side = new Triceritots();
            Tyrannotea t = new Tyrannotea();
            c.Drink = t;

            v.HoldCheese();
            t.AddLemon();

            Assert.Contains("Hold Cheese", c.Special);
            Assert.Contains("Small Triceritots", c.Special);
            Assert.Contains("Small Tyrannotea", c.Special);
            Assert.Contains("Add Lemon", c.Special);
            Assert.Equal(4, c.Special.Length);
        }
    }
}
