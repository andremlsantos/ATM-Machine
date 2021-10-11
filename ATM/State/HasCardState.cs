using ATM.Context;
using State.State;
using System;

namespace ATM.State
{
    /*
     * The card is already inside the machine
     */
    public class HasCardState : IAtmState
    {
        private readonly AtmMachine _atmMachine;
        private static int CorrectPin => 1234;

        public HasCardState(AtmMachine atmMachine)
        {
            _atmMachine = atmMachine;
        }

        public void InsertCard()
        {
            // if you have a card, and still want to insert it
            Console.WriteLine("You can not enter more than one card");
        }

        public void EjectCard()
        {
            Console.WriteLine("Card Ejected");

            _atmMachine.CurrentState = _atmMachine.NoCard;
        }

        /*
         * We already entered a card
         * Now we need to validate the pin
         */
        public void InsertPin(int pin)
        {
            if (IsCorrectPin(pin))
            {
                Console.WriteLine("Correct pin");

                _atmMachine.IsPinCorrect = true;
                _atmMachine.CurrentState = _atmMachine.HasCorrectPin;
            }
            else
            {
                Console.WriteLine("Wrong pin");
                _atmMachine.IsPinCorrect = false;

                Console.WriteLine("Card ejected");
                _atmMachine.CurrentState = _atmMachine.NoCard;
            }
        }

        private static bool IsCorrectPin(int pin)
        {
            return pin == CorrectPin;
        }

        public void RequestCash(int amount)
        {
            Console.WriteLine("Enter the pin first");
        }
    }
}