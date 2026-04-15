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
