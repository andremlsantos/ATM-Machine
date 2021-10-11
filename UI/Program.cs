using ATM.Context;
using ATM.Proxy;
using System;

namespace UI
{
    static class Program
    {
        static void Main(string[] args)
        {
            var realAtm = RealAtmUseCase();

            Console.WriteLine("---- ---- ---- ----");

            ProxyAtmUseCase(realAtm);
        }

        private static void ProxyAtmUseCase(AtmMachine realAtm)
        {
            var proxy = new AtmProxy(realAtm);

            var balance = proxy.GetBalance();
            Console.WriteLine($"The current balance is {balance}");

            var currentState = proxy.GetData();
            Console.WriteLine($"The current state is {currentState.GetStateName()}");
        }

        static AtmMachine RealAtmUseCase()
        {
            const int initialBalance = 15000;
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

            return atm;
        }
    }
}
