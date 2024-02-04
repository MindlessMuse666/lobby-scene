using System;
using UnityEngine;

namespace Hero.Settings
{
    [Serializable]
    public class HeroSettings
    {
        [field: SerializeField]
        public string Name { get; set; }

        [field: SerializeField]
        public int Level { get; set; }

        [field: SerializeField]
        public float Experience { get; set; }

        [field: SerializeField]
        public string Description { get; set; }

        [field: SerializeField]
        public float Health { get; set; }

        [field: SerializeField]
        public float Attack { get; set; }

        [field: SerializeField]
        public float Defense { get; set; }

        [field: SerializeField]
        public float Speed { get; set; }

        [field: SerializeField]
        public HeroType Type { get; set; }

        [field: SerializeField]
        public bool WasBought { get; set; }

        [field: SerializeField]
        public int Price { get; set; }

        [field: SerializeField]
        public bool IsSelected { get; set; }
    }
}