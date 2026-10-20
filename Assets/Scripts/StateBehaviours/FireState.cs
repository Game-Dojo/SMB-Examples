using System.Collections.Generic;
using UnityEngine;

public class FireState : StateMachineBehaviour
{
    private PlayerController _player;
    private ParticleSystem _fireParticles;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_player == null)
        {
            var parentObject = animator.gameObject;
            
            _player = parentObject.GetComponent<PlayerController>();

            var particleSystem = parentObject.transform.GetChild(1).GetChild((int)EffectZone.Effects.Fire); 
            _fireParticles = particleSystem.GetComponent<ParticleSystem>();
        }

        if (_fireParticles) _fireParticles.Play();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_fireParticles) _fireParticles.Stop();
        _player.ResetEffects();
    }
}
