using CheckoutTask;

namespace CheckoutTests
{
    public class CheckoutMainTests
    {
        private Checkout CreateCheckout()
        {
            var unitPrices = new Dictionary<string, int>
            {
                { "A", 50 },
                { "B", 30 },
                { "C", 20 },
                { "D", 15 }
            };

            var specialPrices = new Dictionary<string, (int quantity, int specialPrice)>
            {
                { "A", (3, 130) },
                { "B", (2, 45) }
            };

            return new Checkout(unitPrices, specialPrices);
        }

        [Fact]
        public void TestSingleItem()
        {
            var checkout = CreateCheckout();
            checkout.Scan("A");
            Assert.Equal(50, checkout.GetTotalPrice());
        }


        [Fact]
        public void TestMultipleItemsWithoutSpecialPrice()
        {
            var checkout = CreateCheckout();
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            Assert.Equal(100, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestSpecialPriceA()
        {
            var checkout = CreateCheckout();
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.Equal(130, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestSpecialPriceB()
        {
            var checkout = CreateCheckout();
            checkout.Scan("B");
            checkout.Scan("B");
            Assert.Equal(45, checkout.GetTotalPrice());
        }


        [Fact]
        public void TestMixedItems()
        {
            var checkout = CreateCheckout();
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C");
            Assert.Equal(195, checkout.GetTotalPrice());
        }


        [Fact]
        public void TestDifferentOrder()
        {
            var checkout = CreateCheckout();
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.Equal(175, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestNoItems()
        {
            var checkout = CreateCheckout();
            Assert.Equal(0, checkout.GetTotalPrice());
        }

        
        [Fact]
        public void TestBoundarySpecialPriceA()
        {
            var checkout = CreateCheckout();
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.Equal(130, checkout.GetTotalPrice());
        }
    }
}