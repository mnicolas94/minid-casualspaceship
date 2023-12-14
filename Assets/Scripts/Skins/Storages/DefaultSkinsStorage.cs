using UnityEngine;
using Unlockables;

namespace Skins.Storages
{
    [CreateAssetMenu(fileName = "DefaultSkinsStorage", menuName = "Skins/Unlock Storages/Default", order = 0)]
    public class DefaultSkinsStorage : StorageUnlockedByDefault<SkinData>
    {
        
    }
}