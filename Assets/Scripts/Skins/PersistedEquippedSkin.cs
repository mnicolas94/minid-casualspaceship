using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Skins
{
    [CreateAssetMenu(fileName = "PersistedEquippedSkin", menuName = "Skins/PersistedEquippedSkin", order = 0)]
    public class PersistedEquippedSkin : ScriptableObject
    {
        [SerializeField] private AssetReferenceT<SkinData> _skin;
    }
}