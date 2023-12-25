using System;
using System.Collections.Generic;
using System.Linq;
using TNRD;
using TriInspector;
using UnityEditor;
using UnityEngine;
using Unlockables;

namespace Skins
{
    [CreateAssetMenu(fileName = "SkinCostTable", menuName = "Skins/SkinCostTable", order = 0)]
    public class SkinCostTable : ScriptableObject
    {
        [TableList(Draggable = false, ShowElementLabels = false)]
        [SerializeField] private List<SkinCost> _costs;

#if UNITY_EDITOR
        private void OnEnable()
        {
            UpdateList();
        }

        [ContextMenu(nameof(UpdateList))]
        private void UpdateList()
        {
            var newSkins = AssetDatabase.FindAssets("t:SkinData")
                .Select(guid => new AddressableSkinData(guid))
                .Where(skin => !_costs.Exists(skinCost => skinCost.skin.Equals(skin)));
            
            foreach (var addressableSkin in newSkins)
            {
                var skinCost = new SkinCost()
                {
                    skin = addressableSkin
                };
                _costs.Add(skinCost);
            }
        }
#endif
        public IUnlockCost GetCost(AddressableSkinData skin)
        {
            return _costs.Find(skinCost => skinCost.skin.Equals(skin)).unlockCost.Value;
        }
    }

    [Serializable]
    public class SkinCost
    {
        public AddressableSkinData skin;
        public SerializableInterface<IUnlockCost> unlockCost;
    }
}