using ATM.Context;
using ATM.State;

namespace ATM.Factory
{
    public class AtmStateFactory
    {
        public IAtmState Create(StateType type, AtmMachine atm)
        {
            return type switch
            {
                StateType.HasCard => new HasCard(atm),
                StateType.HasCorrectPin => new HasCorrectPin(atm),
                StateType.NoCard => new NoCard(atm),
                StateType.NoCash => new NoCash(atm),
                _ => new UnknownAtmState()
            };
        }
    }
}
