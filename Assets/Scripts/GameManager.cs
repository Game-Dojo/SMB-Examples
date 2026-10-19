using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
   private Animator _animator;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   public void Update()
   {
      if (Keyboard.current.spaceKey.wasPressedThisFrame)
      {
         SetOnFire();
      }
   }

   public void SetOnFire()
   {
      _animator.SetTrigger("OnFire");
   }

   public void NoFire()
   {
      
   }
}
