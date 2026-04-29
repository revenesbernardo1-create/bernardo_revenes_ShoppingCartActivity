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

    class Program
    {
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

            string userChoice = "Y";

            do
            {
                Console.WriteLine("\n===== STORE MENU =====");
                Console.WriteLine("ID    Name                 Category        Price      Stock");

                for (int i = 0; i < itemsList.Length; i++)
                {
                    itemsList[i].ShowItem();
                }

                int chosenId = GetValidNumber("\nEnter product ID: ");

                if (chosenId < 1 || chosenId > itemsList.Length)
                {
                    Console.WriteLine("Invalid product ID.");
                    continue;
                }

                Item selectedItem = itemsList[chosenId - 1];

                if (selectedItem.stockLeft == 0)
                {
                    Console.WriteLine("Out of stock.");
                    continue;
                }

                int quantity = GetValidNumber("Enter quantity: ");

                if (quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    continue;
                }

                if (quantity > selectedItem.stockLeft)
                {
                    Console.WriteLine("Not enough stock available.");
                    continue;
                }

                bool existingItem = false;

               
                for (int i = 0; i < cartCount; i++)
                {
                    if (cartIds[i] == chosenId)
                    {
                        cartQty[i] += quantity;
                        cartSubtotals[i] = selectedItem.ComputeTotal(cartQty[i]);
                        existingItem = true;
                        break;
                    }
                }

               
                if (!existingItem)
                {
                    cartIds[cartCount] = chosenId;
                    cartQty[cartCount] = quantity;
                    cartSubtotals[cartCount] = selectedItem.ComputeTotal(quantity);
                    cartCount++;
                }

                
                selectedItem.stockLeft -= quantity;

                Console.WriteLine("Item added to cart.");

                userChoice = GetYesNoInput("Add another item? (Y/N): ");

            } while (userChoice == "Y");

            PrintReceipt(itemsList, cartIds, cartQty, cartSubtotals, cartCount);

            Console.WriteLine("\nThank you for shopping!");
        }

        
        static void PrintReceipt(Item[] items, int[] ids, int[] qtys, double[] subtotals, int count)
        {
            double totalAmount = 0;

            Console.WriteLine("\n===== RECEIPT =====");
            Console.WriteLine("Item                 Qty        Subtotal");

            for (int i = 0; i < count; i++)
            {
                string productName = items[ids[i] - 1].itemName;

                Console.WriteLine($"{productName,-20} {qtys[i],-10} {subtotals[i],-10}");
                totalAmount += subtotals[i];
            }

            Console.WriteLine($"\nGrand Total: {totalAmount}");

            double discount = 0;

            if (totalAmount >= 5000)
            {
                discount = totalAmount * 0.10;
                Console.WriteLine($"Discount (10%): {discount}");
            }

            double finalTotal = totalAmount - discount;
            Console.WriteLine($"Final Total: {finalTotal}");
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

        
        static string GetYesNoInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine().ToUpper();

                if (input == "Y" || input == "N")
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter Y or N only.");
            }
        }
    }
}
