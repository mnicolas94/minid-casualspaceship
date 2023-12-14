using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Currency
{
    [CreateAssetMenu(fileName = "Currency", menuName = "Currency/Currency", order = 0)]
    public class Currency : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private IntVariable _variable;

        public Sprite Sprite => _sprite;
        public IntVariable Variable => _variable;
    }
}