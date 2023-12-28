using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Currency
{
    [CreateAssetMenu(fileName = "Currency", menuName = "Currency/Currency", order = 0)]
    public class Currency : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite => _sprite;
        
        [SerializeField] private IntVariable _variable;
        public IntVariable Variable => _variable;
        
        /// <summary>
        /// currency count collected during a game. On game over, this amount is added to the actual/total
        /// currency variable.
        /// </summary>
        [SerializeField] private IntVariable _currentInGame;
        public IntVariable CurrentInGame => _currentInGame;
    }
}