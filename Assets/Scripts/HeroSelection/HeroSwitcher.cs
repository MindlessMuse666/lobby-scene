using System;
using System.Collections.Generic;
using Hero;
using UnityEngine;

namespace HeroSelection
{
    public class HeroSwitcher : MonoBehaviour
    {
        public event Action<HeroController> HeroChanged;

        private IReadOnlyList<HeroController> _heroControllers;
        private HeroController _currentHeroController;

        public void Initialize(IReadOnlyList<HeroController> heroControllers)
        {
            _heroControllers = heroControllers;
        }

        public void SetCurrentHero(HeroController heroController)
        {
            _currentHeroController = heroController;
        }

        public void GoToPreviousHero()
        {
            ChangeHero(-1);
        }

        public void GoToNextHero()
        {
            ChangeHero(1);
        }

        private void ChangeHero(int direction)
        {
            if (_currentHeroController != null)
            {
                _currentHeroController.gameObject.SetActive(false);
            }

            var currentIndex = GetIndexOfCurrentHero();
            var newIndex = (currentIndex + direction + _heroControllers.Count) % _heroControllers.Count;

            _currentHeroController = _heroControllers[newIndex];
            _currentHeroController.gameObject.SetActive(true);

            HeroChanged?.Invoke(_currentHeroController);
        }

        private int GetIndexOfCurrentHero()
        {
            for (var i = 0; i < _heroControllers.Count; i++)
            {
                if (_heroControllers[i] == _currentHeroController)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}