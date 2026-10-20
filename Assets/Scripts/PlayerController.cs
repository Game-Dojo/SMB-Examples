using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    
    private Animator _animator;
    private Vector3 _movement;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();

        moveAction.action.performed += OnMovement;
        moveAction.action.canceled += OnStop;
    }

    private void OnMovement(InputAction.CallbackContext obj)
    {
        _movement = new Vector3(obj.ReadValue<Vector2>().x, obj.ReadValue<Vector2>().y, 0);
    }

    private void OnStop(InputAction.CallbackContext obj)
    {
        _movement = Vector3.zero;
    }

    private void Update()
    {
        transform.position += _movement * (5.0f * Time.deltaTime);
    }

    public void SetOnFire()
    {
        print("SET ON FIRE");
        _animator.SetInteger("Effect", (int) EffectZone.Effects.Fire);
    }
    
    public void SetOnFreeze()
    {
        _animator.SetInteger("Effect", (int) EffectZone.Effects.Freeze);
    }
    
    public void SetOnPoison()
    {
        _animator.SetInteger("Effect", (int) EffectZone.Effects.Poison);
    }

    public void ResetEffects()
    {
        _animator.SetInteger("Effect", -1);
    }

    private void OnDestroy()
    {
        moveAction.action.performed -= OnMovement;
        moveAction.action.canceled -= OnStop;
    }
}
