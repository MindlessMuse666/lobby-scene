using TMPro;
using UnityEngine;

namespace Currency
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyLabel;

        public void UpdateMoneyView(int value)
        {
            _moneyLabel.text = value.ToString();
        }
        
    }
}