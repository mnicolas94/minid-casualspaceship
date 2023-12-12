using BrunoMikoski.AnimationSequencer;
using TriInspector;
using UnityEngine;

namespace Character
{
    [DeclareBoxGroup("animations", Title = "Animations")]
    [DeclareBoxGroup("vfx", Title = "VFX")]
    public class CharacterReferences : MonoBehaviour
    {
        [GroupNext("animations")]
        [SerializeField] private AnimationSequencerController _deadAnimation;
        public AnimationSequencerController DeadAnimation
        {
            get => _deadAnimation;
            set => _deadAnimation = value;
        }

        [SerializeField] private AnimationSequencerController _rebornAnimation;
        public AnimationSequencerController RebornAnimation
        {
            get => _rebornAnimation;
            set => _rebornAnimation = value;
        }
        
        [SerializeField] private AnimationSequencerController _moveToInitialPositionAnimation;
        public AnimationSequencerController MoveToInitialPositionAnimation
        {
            get => _moveToInitialPositionAnimation;
            set => _moveToInitialPositionAnimation = value;
        }
        
        [GroupNext("vfx")]
        [SerializeField] private ParticleSystem _trailParticleSystem;
        public ParticleSystem TrailParticleSystem
        {
            get => _trailParticleSystem;
            set => _trailParticleSystem = value;
        }
    }
}