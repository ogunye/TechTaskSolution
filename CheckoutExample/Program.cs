using CheckoutTask;


//Define unit prices
var unitPrices = new Dictionary<string, int>
            {
                { "A", 50 },
                { "B", 30 },
                { "C", 20 },
                { "D", 15 }
            };

// Define special prices
var specialPrices = new Dictionary<string, (int quantity, int specialPrice)>
            {
                { "A", (3, 130) },
                { "B", (2, 45) }
            };

// Create an instance of Checkout with dynamic pricing rules
var checkout = new Checkout(unitPrices, specialPrices);

// Scan items
checkout.Scan("A");
checkout.Scan("A");
checkout.Scan("A");
checkout.Scan("B");
checkout.Scan("B");
checkout.Scan("C");

// Get total price
int totalPrice = checkout.GetTotalPrice();
Console.WriteLine($"Total Price: {totalPrice}"); // Output: Total Price: 195
        
