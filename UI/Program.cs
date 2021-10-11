using ATM.Context;
using ATM.Factory;
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
        }

        static AtmMachine RealAtmUseCase()
        {

            var factory = new AtmStateFactory();
            var atm = new AtmMachine(factory);

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

            const int initialBalance = 15000;
            Console.WriteLine($"The new Balance should be {initialBalance - amountToWithdrawal}");
            Console.WriteLine($"The actual Balance is {actualBalance}");

            return atm;
        }
    }
}
