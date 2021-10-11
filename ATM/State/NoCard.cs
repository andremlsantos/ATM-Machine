using ATM.Context;
using ATM.Factory;
using System;

namespace ATM.State
{
    public class NoCard : IAtmState
    {
        private readonly AtmMachine _atmMachine;

        public NoCard(AtmMachine atmMachine)
        {
            _atmMachine = atmMachine;
        }

        /*
         * We do not have card, we need to insert it
         * And we move to the next state
         */
        public void InsertCard()
        {
            Console.WriteLine("Card Entered");
            Console.WriteLine("Please enter a pin");

            _atmMachine.SetCurrentState(StateType.HasCard);
        }

        public void EjectCard()
        {
            Console.WriteLine("You can not eject a card, because there is no card");
            Console.WriteLine("Enter a card first");
        }

        public void InsertPin(int pin)
        {
            Console.WriteLine("You can not enter a pin, because there is no card");
            Console.WriteLine("Enter a card first");
        }

        public void RequestCash(int amount)
        {
            Console.WriteLine("You can not request money, because there is no card");
            Console.WriteLine("Enter a card first");
        }
    }
}