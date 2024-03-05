using System;

public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice, InventoryItem item1, InventoryItem item2)
    {
        Console.Write("\nEnter item ID to update price: ");
        int itemId = int.Parse(Console.ReadLine());
        if (itemId == item1.ItemId)
        {
            Console.Write("Enter new price: ");
            newPrice = double.Parse(Console.ReadLine());
            item1.Price = newPrice;
        }
        else if (itemId == item2.ItemId)
        {
            Console.Write("Enter new price: ");
            newPrice = double.Parse(Console.ReadLine());
            item2.Price = newPrice;
        }
        else
        {
            Console.WriteLine("\nError! Item not found!");
        }
    }

    // Restock the item
    public void RestockItem(int additionalQuantity, InventoryItem item1, InventoryItem item2)
    {
        Console.Write("\nEnter item ID to restock: ");
        int restockItemId = int.Parse(Console.ReadLine());
        if (restockItemId == item1.ItemId)
        {
            Console.Write("Enter quantity to be restocked: ");
            additionalQuantity = int.Parse(Console.ReadLine());
            item1.QuantityInStock += additionalQuantity;
        }
        else if (restockItemId == item2.ItemId)
        {
            Console.Write("Enter quantity to be restocked: ");
            additionalQuantity = int.Parse(Console.ReadLine());
            item2.QuantityInStock += additionalQuantity;
        }
        else
        {
            Console.WriteLine("\nError! Item not found!");
        }
    }

    // Sell an item
    public void SellItem(int quantitySold, InventoryItem item1, InventoryItem item2)
    {
        Console.Write("\nEnter item ID to sell: ");
        int sellItemId = int.Parse(Console.ReadLine());
        if (sellItemId == item1.ItemId)
        {
            Console.Write("Enter quantity to sell: ");
            quantitySold = int.Parse(Console.ReadLine());
            if (quantitySold <= item1.QuantityInStock)
            {
                item1.QuantityInStock -= quantitySold;
            }
            else
            {
                Console.WriteLine("\nError! Insufficient stock!");
            }
        }
        else if (sellItemId == item2.ItemId)
        {
            Console.Write("\nEnter quantity to sell: ");
            quantitySold = int.Parse(Console.ReadLine());
            if (quantitySold <= item2.QuantityInStock)
            {
                item2.QuantityInStock -= quantitySold;
            }
            else
            {
                Console.WriteLine("\nError! Insufficient stock!");
            }
        }
        else
        {
            Console.WriteLine("\nError! Item not found!");
        }
    }

    // Check if an item is in stock
    public void IsInStock(InventoryItem item1, InventoryItem item2)
    {
        Console.WriteLine("\nCheck if an item is in stock:");
        Console.Write("Enter item ID: ");
        int id = int.Parse(Console.ReadLine());

        if (id == item1.ItemId)
        {
            if (item1.QuantityInStock > 0)
            {
                Console.WriteLine($"{item1.ItemName} is in stock.");
            }
            else
            {
                Console.WriteLine($"{item1.ItemName} is out of stock.");
            }
        }
        else if (id == item2.ItemId)
        {
            if (item2.QuantityInStock > 0)
            {
                Console.WriteLine($"{item2.ItemName} is in stock.");
            }
            else
            {
                Console.WriteLine($"{item2.ItemName} is out of stock.");
            }
        }
        else
        {
            Console.WriteLine("\nError! Item not found!");
        }
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine("\n");
        Console.WriteLine($"Item Name: {ItemName}");
        Console.WriteLine($"Item ID: {ItemId}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Quantity in Stock: {QuantityInStock}");
    }
}

class Program
{
    // InventoryItem instances
    static InventoryItem item1 { get; } = new InventoryItem("Laptop", 101, 1200.50, 10);
    static InventoryItem item2 { get; } = new InventoryItem("Smartphone", 102, 800.30, 15);

    // Update price of an item
    static void UpdatePrice()
    {
        item1.UpdatePrice(item1.Price, item1, item2);
    }

    // Restock an item
    static void RestockItem()
    {
        item1.RestockItem(0, item1, item2); // 0 is a placeholder here
    }

    // Sell an item
    static void SellItem()
    {
        item1.SellItem(0, item1, item2); // 0 is a placeholder here
    }

    // Check if item is in-stock
    static void IsInStock()
    {
        item1.IsInStock(item1, item2);
    }

    // Print details of all items
    static void PrintDetails()
    {
        item1.PrintDetails();
        item2.PrintDetails();
    }

    // Main method
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Select Option from Menu:");
            Console.WriteLine("1. Update price of an item.");
            Console.WriteLine("2. Restock an item.");
            Console.WriteLine("3. Sell an item.");
            Console.WriteLine("4. Check if item is in-stock?");
            Console.WriteLine("5. Print details of all items.");
            Console.WriteLine("6. Exit.");
            Console.WriteLine("______________________________");

            Console.Write("\nEnter your choice: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        UpdatePrice();
                        break;
                    case 2:
                        RestockItem();
                        break;
                    case 3:
                        SellItem();
                        break;
                    case 4:
                        IsInStock();
                        break;
                    case 5:
                        PrintDetails();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("Error! It's an Invalid choice.");
                        Console.WriteLine("Choose from given options");
                        Console.WriteLine("------------------------------");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }
    }
}