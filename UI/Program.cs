using State.Context;
using System;

namespace UI
{
    static class Program
    {
        static void Main(string[] args)
        {
        }

        static void StatePattern()
        {
            const int initialBalance = 2000;
            var atm = new AtmMachine(initialBalance);

            atm.InsertCard();
            Console.WriteLine();

            atm.EjectCard();
            Console.WriteLine();

            atm.InsertCard();
            Console.WriteLine();

            atm.InsertPin(5555);
            Console.WriteLine();

            atm.RequestCash(5000);
            Console.WriteLine();

            atm.InsertCard();
            Console.WriteLine();

            atm.InsertPin(1234);
            Console.WriteLine();

            const int amountToWithdrawal = 1000;
            atm.RequestCash(amountToWithdrawal);

            var actualBalance = atm.Balance;

            Console.WriteLine($"The new Balance should be {initialBalance - amountToWithdrawal}");
            Console.WriteLine($"The actual Balance is {actualBalance}");
        }
    }
}
