using System;
using Xunit;
using DinoDiner.Menu;

namespace MenuTest
{
    public class EmptyDefaultSpecialTest
    {
        [Theory]
        [InlineData(typeof(Brontowurst))]
        [InlineData(typeof(DinoNuggets))]
        [InlineData(typeof(PrehistoricPBJ))]
        [InlineData(typeof(PterodactylWings))]
        [InlineData(typeof(SteakosaurusBurger))]
        [InlineData(typeof(TRexKingBurger))]
        [InlineData(typeof(VelociWrap))]
        [InlineData(typeof(Fryceritops))]
        [InlineData(typeof(Triceritots))]
        [InlineData(typeof(MeteorMacAndCheese))]
        [InlineData(typeof(MezzorellaSticks))]
        [InlineData(typeof(Tyrannotea))]
        [InlineData(typeof(Sodasaurus))]
        [InlineData(typeof(JurassicJava))]
        [InlineData(typeof(Water))]
        // CretaciousCombo not included because by default it's special includes the side and drink in their entirety
        public void DefaultSpecialShouldBeEmpty(Type type)
        {
            IOrderItem item = (IOrderItem) Activator.CreateInstance(type);
            Assert.Empty(item.Special);
        }
    }
}
