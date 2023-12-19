using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Skins
{
    [CreateAssetMenu(fileName = "PersistedEquippedSkin", menuName = "Skins/PersistedEquippedSkin", order = 0)]
    public class PersistedEquippedSkin : ScriptableObject
    {
        [SerializeField] private AddressableSkinData _spaceshipSkin;
        [SerializeField] private AddressableSkinData _trailSkin;

        public AddressableSkinData SpaceshipSkin
        {
            get => _spaceshipSkin;
            set => _spaceshipSkin = value;
        }

        public AddressableSkinData TrailSkin
        {
            get => _trailSkin;
            set => _trailSkin = value;
        }
    }
}