using DinoDiner.Menu;
using Xunit;

namespace MenuTest
{
    public class OrderTest
    {
        [Fact]
        public void ShouldProperlyCalculatePrice()
        {
            Order o = new Order();

            PrehistoricPBJ p = new PrehistoricPBJ();
            p.Price = 5.55;

            Tyrannotea t = new Tyrannotea();
            t.Price = 1.13;

            o.Items.Add(p);
            o.Items.Add(t);

            Assert.Equal(5.55 + 1.13, o.SubtotalCost);
            Assert.Equal(.1 * (5.55 + 1.13), o.SalesTaxCost);
            Assert.Equal(1.1 * (5.55 + 1.13), o.TotalCost);
        }

        [Fact]
        public void SubtotalCostShouldNotBeNegative()
        {
            Order o = new Order();

            PrehistoricPBJ p = new PrehistoricPBJ();
            p.Price = 5.55;

            Tyrannotea t = new Tyrannotea();
            t.Price = -10852;

            o.Items.Add(p);
            o.Items.Add(t);

            Assert.Equal(0, o.SubtotalCost);
        }
    }
}
