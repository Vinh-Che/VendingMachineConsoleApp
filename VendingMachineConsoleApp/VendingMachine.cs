namespace VendingMachineConsoleApp
{
    using System;
    using System.Collections.Generic;

    public class VendingMachine
    {
        private Dictionary<string, (int Price, int Stock)> products = new Dictionary<string, (int Price, int Stock)>()
    {
        {"Coke", (20, 10)},
        {"Fanta", (20, 10)},
        {"Kvikk Lunsj", (25, 10)},
        {"Water", (15, 10)},
        {"Sprite", (20, 10)},
        {"Coffee", (30, 10)},
        {"Tea", (25, 10)},
        {"Chips", (35, 10)},
        {"Energy Bar", (30, 10)},
        {"Gum", (10, 10)}
    };

        private int credit = 0;

        public int Credit
        {
            get { return credit; }
        }

        public void ListProducts()
        {
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Price}, Stock: {item.Value.Stock}");
            }
        }

        public void InsertMoney(int amount)
        {
            credit += amount;
            Console.WriteLine($"Current credit is {credit}");
        }

        public void RecallMoney()
        {
            Console.WriteLine($"Giving out {credit}");
            credit = 0;
        }

        public void OrderProduct(string product)
        {
            if (products.ContainsKey(product))
            {
                var item = products[product];
                if (credit >= item.Price)
                {
                    if (item.Stock > 0)
                    {
                        credit -= item.Price; // Deduct the price from the current credit
                        item.Stock -= 1;
                        products[product] = item; // Update stock

                        // Updated to show remaining credit instead of resetting it to 0
                        Console.WriteLine($"Giving out {product}. Remaining credit: {credit}");
                    }
                    else
                    {
                        Console.WriteLine($"{product} is out of stock.");
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough credit, need {item.Price - credit} more");
                }
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }


        // Service functionality to fill up the stock
        public void FillStock(string product, int amount)
        {
            if (products.ContainsKey(product))
            {
                var item = products[product];
                item.Stock += amount;
                products[product] = item; // Update the stock
                Console.WriteLine($"{product} stock filled. New stock: {item.Stock}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }
    }

}
