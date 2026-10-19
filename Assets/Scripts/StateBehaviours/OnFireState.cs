using UnityEngine;

public class OnFireState : StateMachineBehaviour
{
    private GameManager _gameManager;
    private ParticleSystem _fireParticles;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_gameManager == null)
        {
            var parentObject = animator.gameObject;
            
            _gameManager = parentObject.GetComponent<GameManager>();
            _fireParticles = parentObject.GetComponentInChildren<ParticleSystem>();
        }

        if (_fireParticles) _fireParticles.Play();
        //_gameManager.SetOnFire();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_fireParticles) _fireParticles.Stop();
    }
}
