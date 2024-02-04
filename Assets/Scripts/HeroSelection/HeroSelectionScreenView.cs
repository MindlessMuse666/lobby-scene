using System.Collections.Generic;
using Hero;
using Hero.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeroSelection
{
    public class HeroSelectionScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _heroNameText;
        [SerializeField] private Image _typeImage;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _experienceText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Slider _attackSlider;
        [SerializeField] private Slider _defenseSlider;
        [SerializeField] private Slider _speedSlider;
        [SerializeField] private Sprite[] _heroTypesSprite;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _selectButton;


        private readonly Dictionary<HeroType, int> _typeSpriteIndexMap = new()
        {
            { HeroType.Melee, 0 },
            { HeroType.Archer, 1 },
            { HeroType.Mage, 2 }
        };


        public void UpdateHeroSelectionView(HeroSettings heroSettings)
        {
            UpdateButtonView(heroSettings.WasBought);
            UpdateHeroTextData(heroSettings);
            UpdateHeroStatsData(heroSettings);
            UpdateSpriteHeroType(heroSettings.Type);
        }

        private void UpdateButtonView(bool heroWasBought)
        {
            if (heroWasBought)
            {
                _buyButton.gameObject.SetActive(false);
                _selectButton.interactable = true;
            }
            else
            {
                _buyButton.gameObject.SetActive(true);
                _selectButton.interactable = false;
            }
        }

        private void UpdateHeroTextData(HeroSettings heroSettings)
        {
            _heroNameText.text = heroSettings.Name;
            _levelText.text = heroSettings.Level.ToString();
            _experienceText.text = $"{heroSettings.Experience}/100";
            _descriptionText.text = heroSettings.Description;
            _priceText.text = heroSettings.Price.ToString();
        }

        private void UpdateHeroStatsData(HeroSettings heroSettings)
        {
            var maxSettings = HeroesManager.MaxSettings;

            _healthSlider.value = NormalizeValue(heroSettings.Health, 0f, maxSettings.Health);
            _attackSlider.value = NormalizeValue(heroSettings.Attack, 0f, maxSettings.Attack);
            _defenseSlider.value = NormalizeValue(heroSettings.Defense, 0f, maxSettings.Defense);
            _speedSlider.value = NormalizeValue(heroSettings.Speed, 0f, maxSettings.Speed);
        }

        private void UpdateSpriteHeroType(HeroType heroType)
        {
            if (_typeSpriteIndexMap.ContainsKey(heroType))
            {
                var spriteIndex = _typeSpriteIndexMap[heroType];
                _typeImage.sprite = _heroTypesSprite[spriteIndex];
            }
        }

        private float NormalizeValue(float value, float minValue, float maxValue)
        {
            return Mathf.InverseLerp(minValue, maxValue, value);
        }
    }
}