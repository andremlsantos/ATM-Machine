using ATM.Context;
using ATM.State;

namespace ATM.Proxy
{
    public class AtmProxy : IAtmData
    {
        private AtmMachine _atmMachine;

        public AtmProxy(AtmMachine atm = null)
        {
            _atmMachine = atm;
        }

        public IAtmState GetData()
        {
            // lazy initialization
            _atmMachine ??= new AtmMachine(2000);

            return _atmMachine.CurrentState;
        }

        public int GetBalance()
        {
            // lazy initialization
            _atmMachine ??= new AtmMachine(2000);

            return _atmMachine.Balance;
        }
    }
}
