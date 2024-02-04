using System.Collections.Generic; 
using System.Linq;
using Hero.Settings;
using UnityEngine;

namespace Hero
{
    public class HeroesManager : MonoBehaviour
    {
        public IReadOnlyList<HeroController> HeroControllers => _heroControllers;

        public static readonly HeroSettings MaxSettings = new()
        {
            Health = 200,
            Attack = 20,
            Defense = 10,
            Speed = 10
        };

        [SerializeField] private HeroController[] _heroPrefabs;
        [SerializeField] private Transform _heroHolder;


        private readonly List<HeroController> _heroControllers = new();

        private void Awake()
        {
            InstantiateHeroes();
        }


        private void InstantiateHeroes()
        {
            foreach (var heroPrefab in _heroPrefabs)
            {
                InstantiateHero(heroPrefab);
            }

            ActivateSelectedHero();
        }

        private void InstantiateHero(HeroController heroPrefab)
        {
            var heroController = Instantiate(heroPrefab, _heroHolder);
            heroController.gameObject.SetActive(false);
            _heroControllers.Add(heroController);
        }

        private void ActivateSelectedHero()
        {
            _heroControllers.FirstOrDefault(hero => hero.HeroSettings.IsSelected)?.gameObject.SetActive(true);
        }
    }
}