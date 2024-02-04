using UnityEngine;
using UnityEngine.Events;

namespace Currency
{
    public class CurrencyManager : MonoBehaviour
    {
        public UnityEvent<int> MoneyValueChanged;

        [SerializeField] private int _money = 30000;


        private void Start()
        {
            MoneyValueChanged.Invoke(_money);
        }

        public bool TryBuy(int price)
        {
            if (_money >= price)
            {
                _money -= price;
                MoneyValueChanged.Invoke(_money);
                return true;
            }

            return false;
        }
    
    }
}