using ATM.Context;
using ATM.Factory;
using System;

namespace ATM.State
{
    public class HasCorrectPin : IAtmState
    {
        private readonly AtmMachine _atmMachine;

        public HasCorrectPin(AtmMachine atmMachine)
        {
            _atmMachine = atmMachine;
        }

        public void InsertCard()
        {
            Console.WriteLine("You can not enter more than one card");
        }

        public void EjectCard()
        {
            Console.WriteLine("Card Ejected");

            _atmMachine.SetCurrentState(StateType.NoCard);
        }

        public void InsertPin(int pin)
        {
            Console.WriteLine("You already entered a pin");
        }

        /*
         * We entered the correct pin already, so, we should be able to request cash
         */
        public void RequestCash(int amount)
        {
            if (IsInvalidAmount(amount))
            {
                Console.WriteLine("You do not have enough money");
                Console.WriteLine("Card ejected");

                _atmMachine.SetCurrentState(StateType.NoCard);
            }
            else
            {
                Console.WriteLine($"The following {amount} will be provided by the machine");

                var newBalance = _atmMachine.Balance - amount;
                Console.WriteLine($"Updating the balance to {newBalance}");

                _atmMachine.Balance = newBalance;

                Console.WriteLine("Card ejected");
                _atmMachine.SetCurrentState(StateType.NoCard);

                if (IsOutBalance())
                {
                    _atmMachine.SetCurrentState(StateType.NoCash);
                }
            }
        }

        private bool IsOutBalance()
        {
            return _atmMachine.Balance < 0;
        }

        private bool IsInvalidAmount(int amount)
        {
            return amount > _atmMachine.Balance;
        }
    }
}