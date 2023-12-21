using System;
using UnityEngine.AddressableAssets;

namespace Skins
{
    [Serializable]
    public class AddressableSkinData : AssetReferenceT<SkinData>
    {
        public AddressableSkinData(string guid) : base(guid)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is AddressableSkinData other)
            {
                return Equals(other);
            }
            
            return false;
        }

        public bool Equals(AddressableSkinData other)
        {
            if (other != null)
            {
                return RuntimeKey.Equals(other.RuntimeKey);
            }
            
            return false;
        }
    }
}