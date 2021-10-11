using ATM.State;

namespace ATM.Proxy
{
    /*
     * We specify only the minimum methods necessary to interact with ATM
     * For security reasons, we don't want to expose more behavior like: add money, remove money and so on
     */
    public interface IAtmProxy
    {
        public IAtmState GetData();
        public int GetBalance();
    }
}