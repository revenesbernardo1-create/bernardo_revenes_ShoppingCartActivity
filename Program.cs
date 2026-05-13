using System;
namespace quiz
{
    class Item
    {
        public int itemCode;
        public string itemName;
        public double itemPrice;
        public int stockLeft;

        public void ShowItem()
        {
            Console.WriteLine($"{itemCode, -5} {itemName, -15} {itemPrice, -10} {stockLeft, -10}");
        }

        public double ComputeTotal(int amount)
        {
            return itemPrice * amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Item[] itemsList = new Item[] {
            new Item { itemCode=1, itemName="Laptop", itemPrice=35000, stockLeft=10 },
            new Item { itemCode=2, itemName="Smartphone", itemPrice=18000, stockLeft=15 },
            new Item { itemCode=3, itemName="Tablet", itemPrice=12000, stockLeft=12 },
            new Item { itemCode=4, itemName="Smartwatch", itemPrice=5000, stockLeft=20 },
            new Item { itemCode=5, itemName="Bluetooth Speaker", itemPrice=2500, stockLeft=25 }
            };

            int[] selectedIds = new int[10];
            int[] selectedQty = new int[10];
            double[] subTotals = new double[10];
            int totalItems = 0;

            string userChoice = "Y";

             do
            {
                Console.WriteLine("\n----- STORE MENU -----");
                Console.WriteLine("ID    Name            Price      Stock");

                for (int i = 0; i < itemsList.Length; i++)
                {
                    itemsList[i].ShowItem();
                }

                Console.Write("\nEnter product ID: ");
                int chosenId;
                if (!int.TryParse(Console.ReadLine(), out chosenId) || chosenId < 1 || chosenId > itemsList.Length)
                {
                    Console.WriteLine("Invalid product number!");
                    continue;
                }

                Item chosenItem = itemsList[chosenId - 1];

                if (chosenItem.stockLeft == 0)
                {
                    Console.WriteLine("Out of stock!");
                    continue;
                }

                Console.Write("Enter quantity: ");
                int quantityInput;
                if (!int.TryParse(Console.ReadLine(), out quantityInput) || quantityInput <= 0)
                {
                    Console.WriteLine("Invalid quantity!");
                    continue;
                }
                   if (quantityInput > chosenItem.stockLeft)
                {
                    Console.WriteLine("Not enough stock available.");
                    continue;
                }

                bool alreadyInCart = false;

                for (int i = 0; i < totalItems; i++)
                {
                    if (selectedIds[i] == chosenId)
                    {
                        selectedQty[i] += quantityInput;
                        subTotals[i] = itemsList[chosenId - 1].ComputeTotal(selectedQty[i]);
                        alreadyInCart = true;
                        break;
                    }
                }

                if (!alreadyInCart)
                {
             if (totalItems >= selectedIds.Length)
                    {
                        Console.WriteLine("Cart is full.");
                        continue;
                    }

                    selectedIds[totalItems] = chosenId;
                    selectedQty[totalItems] = quantityInput;
                    subTotals[totalItems] = chosenItem.ComputeTotal(quantityInput);
                    totalItems++;
                }

                chosenItem.stockLeft -= quantityInput;

                Console.WriteLine("Item added to cart!");

                Console.Write("Add more? (Y/N): ");
                userChoice = Console.ReadLine().ToUpper();

            } while (userChoice == "Y");

            double totalAmount = 0;

            Console.WriteLine("\n----- RECEIPT -----");
            Console.WriteLine("Item            Quantity   Subtotal");

            for (int i = 0; i < totalItems; i++)
            {
                string productName = itemsList[selectedIds[i] - 1].itemName;
                Console.WriteLine($"{productName,-15} {selectedQty[i],-10} {subTotals[i],-10}");
                totalAmount += subTotals[i];
            }

            Console.WriteLine($"\nGrand Total: {totalAmount}");

            double discountValue = 0;

            if (totalAmount >= 5000)
            {
                discountValue = totalAmount * 0.10;
                Console.WriteLine($"Discount (10%): {discountValue}");
            }

            double netTotal = totalAmount - discountValue;

            Console.WriteLine($"Final Total: {netTotal}");

            Console.WriteLine("\n----- UPDATED STOCK -----");
            Console.WriteLine("ID    Name            Price      Stock");

            for (int i = 0; i < itemsList.Length; i++)
            {
                itemsList[i].ShowItem();
            }

            Console.WriteLine("\nThank you for shopping!");
        }
    }
}






_________________________Enhanced ShoppingCartActivity___________________________________________



using System;

namespace quiz
{
    class Item
    {
        public int itemCode;
        public string itemName;
        public string category;
        public double itemPrice;
        public int stockLeft;

        public void ShowItem()
        {
            Console.WriteLine($"{itemCode,-5} {itemName,-20} {category,-15} {itemPrice,-10} {stockLeft,-10}");
        }

        public double ComputeTotal(int quantity)
        {
            return itemPrice * quantity;
        }
    }

    class Order
    {
        public string receiptNumber;
        public double finalTotal;
        public string orderDate;
    }

    class Program
    {
        static int receiptCounter = 1;

        static void Main(string[] args)
        {
            Item[] itemsList = new Item[]
            {
                new Item { itemCode = 1, itemName = "Laptop", category = "Electronics", itemPrice = 35000, stockLeft = 10 },
                new Item { itemCode = 2, itemName = "Smartphone", category = "Electronics", itemPrice = 18000, stockLeft = 15 },
                new Item { itemCode = 3, itemName = "Tablet", category = "Electronics", itemPrice = 12000, stockLeft = 12 },
                new Item { itemCode = 4, itemName = "Smartwatch", category = "Wearables", itemPrice = 5000, stockLeft = 20 },
                new Item { itemCode = 5, itemName = "Bluetooth Speaker", category = "Audio", itemPrice = 2500, stockLeft = 25 }
            };

            int[] cartIds = new int[10];
            int[] cartQty = new int[10];
            double[] cartSubtotals = new double[10];
            int cartCount = 0;

            Order[] orderHistory = new Order[10];
            int orderCount = 0;

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== STORE MENU =====");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Search Product");
                Console.WriteLine("3. Add to Cart");
                Console.WriteLine("4. Cart Menu");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("6. View Order History");

                int menuChoice = GetValidNumber("Choose option: ");

                switch (menuChoice)
                {
                    case 1:
                        DisplayProducts(itemsList);
                        break;

                    case 2:
                        SearchProduct(itemsList);
                        break;

                    case 3:
                        AddToCart(itemsList, cartIds, cartQty, cartSubtotals, ref cartCount);
                        break;

                    case 4:
                        CartMenu(itemsList, cartIds, cartQty, cartSubtotals, ref cartCount);
                        break;

                    case 5:
                        Checkout(itemsList, cartIds, cartQty, cartSubtotals, ref cartCount,
                            orderHistory, ref orderCount);
                        break;

                    case 6:
                        ShowOrderHistory(orderHistory, orderCount);
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                running = GetYesNo("\nContinue program? (Y/N): ");
            }

            Console.WriteLine("\nThank you for shopping!");
        }

        static void DisplayProducts(Item[] items)
        {
            Console.WriteLine("\nID    Name                 Category        Price      Stock");

            for (int i = 0; i < items.Length; i++)
            {
                items[i].ShowItem();
            }
        }

        static void SearchProduct(Item[] items)
        {
            Console.Write("\nEnter product name to search: ");
            string keyword = Console.ReadLine().ToLower();

            bool found = false;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].itemName.ToLower().Contains(keyword))
                {
                    items[i].ShowItem();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching product found.");
            }
        }

        static void AddToCart(Item[] items, int[] ids, int[] qtys,
            double[] subtotals, ref int cartCount)
        {
            DisplayProducts(items);

            int chosenId = GetValidNumber("\nEnter product ID: ");

            if (chosenId < 1 || chosenId > items.Length)
            {
                Console.WriteLine("Invalid product ID.");
                return;
            }

            Item selectedItem = items[chosenId - 1];

            int quantity = GetValidNumber("Enter quantity: ");

            if (quantity <= 0 || quantity > selectedItem.stockLeft)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            ids[cartCount] = chosenId;
            qtys[cartCount] = quantity;
            subtotals[cartCount] = selectedItem.ComputeTotal(quantity);
            cartCount++;

            selectedItem.stockLeft -= quantity;

            Console.WriteLine("Item added to cart.");
        }

        static void CartMenu(Item[] items, int[] ids, int[] qtys,
            double[] subtotals, ref int cartCount)
        {
            Console.WriteLine("\n===== CART MENU =====");
            Console.WriteLine("1. View Cart");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Clear Cart");

            int choice = GetValidNumber("Choose option: ");

            switch (choice)
            {
                case 1:
                    ViewCart(items, ids, qtys, subtotals, cartCount);
                    break;

                case 2:
                    RemoveItem(items, ids, qtys, subtotals, ref cartCount);
                    break;

                case 3:
                    cartCount = 0;
                    Console.WriteLine("Cart cleared.");
                    break;
            }
        }

        static void ViewCart(Item[] items, int[] ids, int[] qtys,
            double[] subtotals, int cartCount)
        {
            double total = 0;

            Console.WriteLine("\n===== YOUR CART =====");

            for (int i = 0; i < cartCount; i++)
            {
                Console.WriteLine($"{items[ids[i] - 1].itemName} | Qty: {qtys[i]} | {subtotals[i]}");
                total += subtotals[i];
            }

            Console.WriteLine($"Grand Total: {total}");
        }

        static void RemoveItem(Item[] items, int[] ids, int[] qtys,
            double[] subtotals, ref int cartCount)
        {
            int removeId = GetValidNumber("Enter product ID to remove: ");

            for (int i = 0; i < cartCount; i++)
            {
                if (ids[i] == removeId)
                {
                    items[removeId - 1].stockLeft += qtys[i];

                    for (int j = i; j < cartCount - 1; j++)
                    {
                        ids[j] = ids[j + 1];
                        qtys[j] = qtys[j + 1];
                        subtotals[j] = subtotals[j + 1];
                    }

                    cartCount--;
                    Console.WriteLine("Item removed.");
                    return;
                }
            }
        }

        static void Checkout(Item[] items, int[] ids, int[] qtys,
            double[] subtotals, ref int cartCount,
            Order[] history, ref int orderCount)
        {
            if (cartCount == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            double totalAmount = 0;

            for (int i = 0; i < cartCount; i++)
            {
                totalAmount += subtotals[i];
            }

            double discount = totalAmount >= 5000 ? totalAmount * 0.10 : 0;
            double finalTotal = totalAmount - discount;

            Console.WriteLine($"\nGrand Total: {totalAmount}");
            Console.WriteLine($"Discount: {discount}");
            Console.WriteLine($"Final Total: {finalTotal}");

            double payment;

            while (true)
            {
                Console.Write("Enter payment: ");

                if (double.TryParse(Console.ReadLine(), out payment))
                {
                    if (payment >= finalTotal)
                        break;

                    Console.WriteLine("Insufficient payment.");
                }
                else
                {
                    Console.WriteLine("Payment must be numeric.");
                }
            }

            double change = payment - finalTotal;
            string receiptNo = receiptCounter.ToString("0000");
            receiptCounter++;

            Console.WriteLine("\n===== RECEIPT =====");
            Console.WriteLine($"Receipt No: {receiptNo}");
            Console.WriteLine($"Date: {DateTime.Now}");
            Console.WriteLine($"Payment: {payment}");
            Console.WriteLine($"Change: {change}");

            history[orderCount] = new Order
            {
                receiptNumber = receiptNo,
                finalTotal = finalTotal,
                orderDate = DateTime.Now.ToString()
            };

            orderCount++;
            cartCount = 0;

            ShowLowStock(items);
        }

        static void ShowLowStock(Item[] items)
        {
            Console.WriteLine("\nLOW STOCK ALERT:");

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].stockLeft <= 5)
                {
                    Console.WriteLine($"{items[i].itemName} has only {items[i].stockLeft} stocks left.");
                }
            }
        }

        static void ShowOrderHistory(Order[] history, int count)
        {
            Console.WriteLine("\n===== ORDER HISTORY =====");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(
                    $"Receipt #{history[i].receiptNumber} | Final Total: {history[i].finalTotal} | {history[i].orderDate}");
            }
        }

        static int GetValidNumber(string message)
        {
            int value;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("Invalid input. Numbers only.");
            }
        }

        static bool GetYesNo(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine().ToUpper();

                if (input == "Y")
                    return true;

                if (input == "N")
                    return false;

                Console.WriteLine("Please enter Y or N only.");
            }
        }
    }
}
