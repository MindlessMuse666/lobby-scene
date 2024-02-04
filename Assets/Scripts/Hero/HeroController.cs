using Hero.Settings;
using UnityEngine;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
        // Атрибут [field: SerializeField] применяется для сериализации полей, соответствующих автосвойствам.
        [field: SerializeField] public HeroSettings HeroSettings { get; set; }
    }
}