namespace ATM.State
{
    public class UnknownAtmState : IAtmState
    {
        public void InsertCard()
        {
            throw new System.NotImplementedException();
        }

        public void EjectCard()
        {
            throw new System.NotImplementedException();
        }

        public void InsertPin(int pin)
        {
            throw new System.NotImplementedException();
        }

        public void RequestCash(int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
