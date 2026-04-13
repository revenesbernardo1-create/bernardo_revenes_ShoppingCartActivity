using System;

namespace quizkopo
{
    class Item
    {
        public int itemCode;
        public string itemName;
        public double itemPrice;
        public int stockLeft;

        public void ShowItem()
        {
            Console.WriteLine($"{itemCode} {itemName} {itemPrice} {stockLeft}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Item[] itemsList = new Item[]
            {
                new Item { itemCode=1, itemName="Mouse", itemPrice=350, stockLeft=50 },
                new Item { itemCode=2, itemName="Keyboard", itemPrice=800, stockLeft=30 }
            };

            for (int i = 0; i < itemsList.Length; i++)
            {
                itemsList[i].ShowItem();
            }
        }
    }
}
