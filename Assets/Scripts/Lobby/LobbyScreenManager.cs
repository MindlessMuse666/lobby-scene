using System.Collections.Generic;
using System.Linq;
using Hero;
using HeroSelection;
using UnityEngine;

namespace Lobby
{
    public class LobbyScreenManager : MonoBehaviour
    {
        [SerializeField] private LobbyScreenView _lobbyScreenView;
        [SerializeField] private HeroSelectionScreenManager _heroSelectionScreenManager;
        private HeroController _currentHeroController;


        public void Initialize(IReadOnlyList<HeroController> heroControllers)
        {
            _heroSelectionScreenManager.Initialize(heroControllers);
            _heroSelectionScreenManager.HeroSelected += OnHeroSelected;
            _currentHeroController = heroControllers.FirstOrDefault(hero => hero.HeroSettings.IsSelected);
            _lobbyScreenView.UpdateUI(_currentHeroController.HeroSettings);
        }


        public void OpenHeroSelectionScreen()
        {
            _heroSelectionScreenManager.OpenScreen(_currentHeroController);
        }

        private void OnHeroSelected(HeroController heroController)
        {
            _currentHeroController = heroController;
            _lobbyScreenView.UpdateUI(heroController.HeroSettings);
        }

        private void OnDestroy()
        {
            _heroSelectionScreenManager.HeroSelected -= OnHeroSelected;
        }
    }
}