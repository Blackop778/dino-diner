using System;
using Xunit;
using DinoDiner.Menu;

namespace MenuTest
{
    public class NotifyPropertyChangedTests
    {
        [Theory]
        [InlineData(typeof(Water))]
        [InlineData(typeof(JurassicJava))]
        [InlineData(typeof(Sodasaurus))]
        [InlineData(typeof(Tyrannotea))]
        public void HoldIceShouldNotify(Type type)
        {
            Drink d = (Drink) Activator.CreateInstance(type);
            Assert.PropertyChanged(d, "Ice", () => d.HoldIce());
            Assert.PropertyChanged(d, "Special", () => d.HoldIce());
        }

        [Theory]
        [InlineData(typeof(Water))]
        [InlineData(typeof(JurassicJava))]
        [InlineData(typeof(Sodasaurus))]
        [InlineData(typeof(Tyrannotea))]
        [InlineData(typeof(MeteorMacAndCheese))]
        [InlineData(typeof(MezzorellaSticks))]
        [InlineData(typeof(Triceritots))]
        [InlineData(typeof(Fryceritops))]
        public void ChangingSizeShouldNotify(Type type)
        {
            AbstractSizedMenuItem s = (AbstractSizedMenuItem)Activator.CreateInstance(type);
            Assert.PropertyChanged(s, "Size", () => s.Size = Size.Small);
            Assert.PropertyChanged(s, "Price", () => s.Size = Size.Small);
            Assert.PropertyChanged(s, "Calories", () => s.Size = Size.Small);
            Assert.PropertyChanged(s, "Description", () => s.Size = Size.Small);

            Assert.PropertyChanged(s, "Size", () => s.Size = Size.Medium);
            Assert.PropertyChanged(s, "Price", () => s.Size = Size.Medium);
            Assert.PropertyChanged(s, "Calories", () => s.Size = Size.Medium);
            Assert.PropertyChanged(s, "Description", () => s.Size = Size.Medium);

            Assert.PropertyChanged(s, "Size", () => s.Size = Size.Large);
            Assert.PropertyChanged(s, "Price", () => s.Size = Size.Large);
            Assert.PropertyChanged(s, "Calories", () => s.Size = Size.Large);
            Assert.PropertyChanged(s, "Description", () => s.Size = Size.Large);
        }

        [Fact]
        public void ChangingComboSizeShouldNotify()
        {
            AbstractSizedMenuItem s = new CretaceousCombo(new PrehistoricPBJ());
            Assert.PropertyChanged(s, "Size", () => s.Size = Size.Small);
            Assert.PropertyChanged(s, "Price", () => s.Size = Size.Small);
            Assert.PropertyChanged(s, "Calories", () => s.Size = Size.Small);
            Assert.PropertyChanged(s, "Special", () => s.Size = Size.Small);

            Assert.PropertyChanged(s, "Size", () => s.Size = Size.Medium);
            Assert.PropertyChanged(s, "Price", () => s.Size = Size.Medium);
            Assert.PropertyChanged(s, "Calories", () => s.Size = Size.Medium);
            Assert.PropertyChanged(s, "Special", () => s.Size = Size.Medium);

            Assert.PropertyChanged(s, "Size", () => s.Size = Size.Large);
            Assert.PropertyChanged(s, "Price", () => s.Size = Size.Large);
            Assert.PropertyChanged(s, "Calories", () => s.Size = Size.Large);
            Assert.PropertyChanged(s, "Special", () => s.Size = Size.Large);
        }

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
        public void ChangingPriceShouldNotify(Type type)
        {
            AbstractMenuItem item = (AbstractMenuItem) Activator.CreateInstance(type);
            Assert.PropertyChanged(item, "Price", () => item.Price = 7.78);
        }

        [Fact]
        public void JurassicJavaShouldNotify()
        {
            JurassicJava j = new JurassicJava();

            Assert.PropertyChanged(j, "Ice", () => j.AddIce());
            Assert.PropertyChanged(j, "Special", () => j.AddIce());

            Assert.PropertyChanged(j, "RoomForCream", () => j.LeaveRoomForCream());
            Assert.PropertyChanged(j, "Special", () => j.AddIce());

            Assert.PropertyChanged(j, "Decaf", () => j.Decaf = true);
            Assert.PropertyChanged(j, "Description", () => j.Decaf = true);
        }

        [Fact]
        public void SodasaurusShouldNotify()
        {
            Sodasaurus s = new Sodasaurus();

            Assert.PropertyChanged(s, "Flavor", () => s.Flavor = SodasaurusFlavor.Orange);
            Assert.PropertyChanged(s, "Description", () => s.Flavor = SodasaurusFlavor.Cola);
        }

        [Fact]
        public void TyrannoteaShouldNotify()
        {
            Tyrannotea t = new Tyrannotea();

            Assert.PropertyChanged(t, "Sweet", () => t.Sweet = true);
            Assert.PropertyChanged(t, "Description", () => t.Sweet = true);
            Assert.PropertyChanged(t, "Calories", () => t.Sweet = true);

            Assert.PropertyChanged(t, "Lemon", () => t.Lemon = true);
            Assert.PropertyChanged(t, "Special", () => t.Lemon = true);
        }

        [Fact]
        public void WaterShouldNotify()
        {
            Water w = new Water();

            Assert.PropertyChanged(w, "Lemon", () => w.Lemon = true);
            Assert.PropertyChanged(w, "Special", () => w.Lemon = true);
        }

        [Fact]
        public void BronowurstShouldNotify()
        {
            Brontowurst b = new Brontowurst();

            Assert.PropertyChanged(b, "Special", () => b.HoldBun());

            Assert.PropertyChanged(b, "Special", () => b.HoldBun());

            Assert.PropertyChanged(b, "Special", () => b.HoldPeppers());
        }

        [Fact]
        public void DinoNuggetsShouldNotify()
        {
            DinoNuggets n = new DinoNuggets();

            Assert.PropertyChanged(n, "Special", () => n.AddNugget());
            Assert.PropertyChanged(n, "Price", () => n.AddNugget());
            Assert.PropertyChanged(n, "Calories", () => n.AddNugget());
        }

        [Fact]
        public void PrehistoricPBJShouldNotify()
        {
            PrehistoricPBJ p = new PrehistoricPBJ();

            Assert.PropertyChanged(p, "Special", () => p.HoldJelly());

            Assert.PropertyChanged(p, "Special", () => p.HoldPeanutButter());
        }

        [Fact]
        public void SteakosaurusBurgerShouldNotify()
        {
            SteakosaurusBurger s = new SteakosaurusBurger();

            Assert.PropertyChanged(s, "Special", () => s.HoldBun());

            Assert.PropertyChanged(s, "Special", () => s.HoldKetchup());

            Assert.PropertyChanged(s, "Special", () => s.HoldMustard());

            Assert.PropertyChanged(s, "Special", () => s.HoldPickle());
        }

        [Fact]
        public void TRexKingBurgerShouldNotify()
        {
            TRexKingBurger k = new TRexKingBurger();

            Assert.PropertyChanged(k, "Special", () => k.HoldBun());

            Assert.PropertyChanged(k, "Special", () => k.HoldKetchup());

            Assert.PropertyChanged(k, "Special", () => k.HoldLettuce());

            Assert.PropertyChanged(k, "Special", () => k.HoldMayo());

            Assert.PropertyChanged(k, "Special", () => k.HoldMustard());

            Assert.PropertyChanged(k, "Special", () => k.HoldOnion());

            Assert.PropertyChanged(k, "Special", () => k.HoldPickle());

            Assert.PropertyChanged(k, "Special", () => k.HoldTomato());
        }

        [Fact]
        public void VelociWrapShouldNotify()
        {
            VelociWrap v = new VelociWrap();

            Assert.PropertyChanged(v, "Special", () => v.HoldCheese());

            Assert.PropertyChanged(v, "Special", () => v.HoldDressing());

            Assert.PropertyChanged(v, "Special", () => v.HoldLettuce());
        }

        [Fact]
        public void CretaceousComboShouldNotify()
        {
            CretaceousCombo c = new CretaceousCombo(new PrehistoricPBJ());

            Assert.PropertyChanged(c, "Entree", () => c.Entree = new PrehistoricPBJ());
            Assert.PropertyChanged(c, "Description", () => c.Entree = new PrehistoricPBJ());
            Assert.PropertyChanged(c, "Special", () => c.Entree = new PrehistoricPBJ());

            Assert.PropertyChanged(c, "Side", () => c.Side = new Fryceritops());
            Assert.PropertyChanged(c, "Special", () => c.Side = new Fryceritops());

            Assert.PropertyChanged(c, "Drink", () => c.Drink = new JurassicJava());
            Assert.PropertyChanged(c, "Special", () => c.Drink = new JurassicJava());
        }
    }
}
