using UnityEngine;
using Unlockables;

namespace Skins.Storages
{
    [CreateAssetMenu(fileName = "LocalSkinsStorage", menuName = "Skins/Unlock Storages/Local", order = 0)]
    public class LocalSkinsStorage : StorageLocal<SkinData>
    {
        
    }
}