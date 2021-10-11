using System;
using State.State;

namespace State.Context
{
    public class AtmMachine : IAtmState
    {
        // All possible states
        public IAtmState HasCard { get; private set; }
        public IAtmState NoCard { get; private set; }
        public IAtmState HasCorrectPin { get; private set; }
        public IAtmState NoCash { get; private set; }
        public IAtmState CurrentState { get; set; }

        public bool IsPinCorrect { get; set; }
        public int Balance { get; private set; }

        public AtmMachine(int initialBalance)
        {
            Balance = initialBalance;

            InitStates();

            CurrentState = NoCard;

            if (IsOutOfBalance())
            {
                CurrentState = NoCash;
            }

            Console.WriteLine("Welcome dear customer");
        }

        private void InitStates()
        {
            HasCard = new HasCardState(this);
            NoCard = new NoCardState(this);
            HasCorrectPin = new HasCorrectPinState(this);
            NoCash = new NoCashState(this);
        }

        private bool IsOutOfBalance()
        {
            return Balance < 0;
        }

        public void InsertCard()
        {
            CurrentState.InsertCard();
        }

        public void EjectCard()
        {
            CurrentState.EjectCard();
        }

        public void InsertPin(int pin)
        {
            CurrentState.InsertPin(pin);
        }

        public void RequestCash(int amount)
        {
            CurrentState.RequestCash(amount);
        }

        public void SetBalance(int value)
        {
            Balance = value;
        }
    }
}