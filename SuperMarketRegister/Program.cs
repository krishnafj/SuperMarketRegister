using System;

namespace SuperMarketRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Supermarket");

            var receipt = new Receipt();
            receipt.AddItem(1, "Candy Bar", 0.50);
            receipt.AddItem(2, "Soda", 1);

            Console.WriteLine(receipt.ToString());

            Console.ReadLine();
        }
    }
}
