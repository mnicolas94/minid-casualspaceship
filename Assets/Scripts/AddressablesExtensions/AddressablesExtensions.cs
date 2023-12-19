using System;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace DefaultNamespace.AddressablesExtensions
{
    public static class AddressablesExtensions
    {
        public static async Task<T> GetOrLoadAssetAsync<T>(this AssetReferenceT<T> reference) where T : Object
        {
            if (reference.Asset != null)//OperationHandle.IsValid() && reference.IsDone)
            {
                return reference.Asset as T;
            }
            else
            {
                if (reference.OperationHandle.IsValid())
                {
                    return await reference.OperationHandle.Task as T;
                }
                else
                {
                    return await reference.LoadAssetAsync().Task;
                }
            }
        }
    }
}