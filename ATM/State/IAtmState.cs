namespace ATM.State
{
    /*
     * All the actions a user can perform
     */
    public interface IAtmState
    {
        public void InsertCard();
        public void EjectCard();
        public void InsertPin(int pin);
        public void RequestCash(int amount);
        public string GetStateName();
    }
}