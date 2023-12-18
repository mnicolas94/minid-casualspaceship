using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Skins
{
    [CreateAssetMenu(fileName = "PersistedEquippedSkin", menuName = "Skins/PersistedEquippedSkin", order = 0)]
    public class PersistedEquippedSkin : ScriptableObject
    {
        [SerializeField] private SkinData _spaceshipSkin;
        [SerializeField] private SkinData _trailSkin;

        public SkinData SpaceshipSkin
        {
            get => _spaceshipSkin;
            set => _spaceshipSkin = value;
        }

        public SkinData TrailSkin
        {
            get => _trailSkin;
            set => _trailSkin = value;
        }
    }
}