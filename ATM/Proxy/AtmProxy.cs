using ATM.Context;
using ATM.Factory;
using ATM.State;

namespace ATM.Proxy
{
    public class AtmProxy : IAtmProxy
    {
        private AtmMachine _atmMachine;

        public AtmProxy(AtmMachine atm = null)
        {
            _atmMachine = atm;
        }

        public IAtmState GetData()
        {
            // lazy initialization
            _atmMachine ??= new AtmMachine(new AtmStateFactory());

            return _atmMachine.CurrentState;
        }

        public int GetBalance()
        {
            // lazy initialization
            _atmMachine ??= new AtmMachine(new AtmStateFactory());

            return _atmMachine.Balance;
        }
    }
}
