using ATM.Factory;
using ATM.Proxy;
using ATM.State;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Context
{
    public class AtmMachine : IAtmProxy
    {
        private readonly AtmStateFactory _factory;
        private readonly Dictionary<StateType, IAtmState> _states = new();
        public IAtmState CurrentState { get; private set; }
        public int Balance { get; set; } = 50000;

        public AtmMachine(AtmStateFactory factory)
        {
            _factory = factory;

            CreateStates();
            SetCurrentState(StateType.NoCard);

            if (IsOutOfBalance())
                SetCurrentState(StateType.NoCash);

            Console.WriteLine("Welcome dear customer");
        }

        private void CreateStates()
        {
            var possibleAtmTypes = Enum.GetValues(typeof(StateType))
                .Cast<StateType>();

            foreach (var type in possibleAtmTypes)
            {
                _states.Add(type, _factory.Create(type, this));
            }
        }

        public void SetCurrentState(StateType type)
        {
            CurrentState = _states[type];
        }

        private bool IsOutOfBalance()
        {
            return Balance < 0;
        }

        /*
         * State
         */
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

        /*
         * Proxy
         */
        public IAtmState GetData()
        {
            return CurrentState;
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}