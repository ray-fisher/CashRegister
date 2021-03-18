using System;

namespace CashReg_Part_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double purchaseStr = Convert("Enter the purchase amount: $");
            double paymentStr = Convert("Enter the payment amount: $");

            while (paymentStr <= 0 || paymentStr < purchaseStr)
            {
                paymentStr = Convert("Enter the payment amount: $");
            }

            double change = paymentStr - purchaseStr;
            Console.WriteLine("\n==========================\n");
            Console.WriteLine($"Your change due is: ${Math.Round(change, 2)}");
            Console.WriteLine("\n==========================\n");
            change = Calculate(change, 20.0, "twenties");
            change = Calculate(change, 10.0, "tens");
            change = Calculate(change, 5.0, "fives");
            change = Calculate(change, 1.0, "ones");
            change = Calculate(change, 0.25, "quarters");
            change = Calculate(change, 0.10, "dimes");
            change = Calculate(change, 0.05, "nickels");
            change = Calculate(change, 0.01, "pennies");
            Console.WriteLine("\n==========================\n");
        }
        static double Convert(string prompt)
        {
            double amount = 0;
            bool attempt = false;
            while (attempt == false)
            {
                try
                {
                    Console.WriteLine(prompt);
                    amount = double.Parse(Console.ReadLine());

                    if (amount <= 0)
                    {
                        Console.WriteLine(prompt);
                        amount = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        attempt = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Uh oh. Something went wrong.");
                }
            }
            return amount;
        }
        static double Calculate(double change, double denomination, string name)
        {
            int changeDue = (int)(change / denomination);
            if (changeDue > 0)
            {
                Console.WriteLine("Received: " + changeDue + " " + name);
            }
            return Math.Round(change % denomination, 2);
        }
    }
}
