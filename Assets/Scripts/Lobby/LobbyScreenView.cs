using Hero.Settings;
using TMPro;
using UnityEngine;

namespace Lobby
{
    public class LobbyScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _heroNameText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _experienceText;

    
        public void UpdateUI(HeroSettings heroSettings)
        {
            _heroNameText.text = heroSettings.Name;
            _levelText.text = heroSettings.Level.ToString();
            _experienceText.text = heroSettings.Experience.ToString();
        }
    }
}