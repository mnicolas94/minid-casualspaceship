using TNRD;
using UnityEngine;
using UnityEngine.Localization;
using Unlockables;

namespace Skins
{
    public enum SkinType
    {
        Spaceship,
        Trail,
    }

    [CreateAssetMenu(fileName = "SkinData", menuName = "Skins/SkinData", order = 0)]
    public class SkinData : ScriptableObject
    {
        [SerializeField] private Sprite _previewSprite;
        [SerializeField] private LocalizedString _skinName;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private SkinType _skinType;

        [SerializeField] private SerializableInterface<IUnlockCost> _unlockCost;

        public Sprite PreviewSprite => _previewSprite;

        public LocalizedString SkinName => _skinName;

        public GameObject Prefab => _prefab;

        public SkinType SkinType => _skinType;

        public IUnlockCost UnlockCost => _unlockCost.Value;
    }
}