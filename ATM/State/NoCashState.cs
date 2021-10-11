using ATM.Context;
using System;

namespace ATM.State
{
    public class NoCashState : IAtmState
    {
        private readonly AtmMachine _atmMachine;

        public NoCashState(AtmMachine atmMachine)
        {
            _atmMachine = atmMachine;
        }

        public void InsertCard()
        {
            Console.WriteLine("You do not have enough money");
            Console.WriteLine("You can not insert card");
        }

        public void EjectCard()
        {
            Console.WriteLine("You do not have enough money");
            Console.WriteLine("You can not eject card");
        }

        public void InsertPin(int pin)
        {
            Console.WriteLine("You do not have enough money");
            Console.WriteLine("You can not insert pin");
        }

        public void RequestCash(int amount)
        {
            Console.WriteLine("You do not have enough money");
            Console.WriteLine("You can not request cash");
        }

        public string GetStateName()
        {
            return nameof(NoCashState);
        }
    }
}