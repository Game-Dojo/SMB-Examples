using UnityEngine;
using UnityEngine.Events;

public class EffectZone : MonoBehaviour
{
    public enum Effects
    {
        Fire,
        Freeze,
        Poison,
    }
    
    [SerializeField] private Effects currentEffect;
    [SerializeField] private UnityEvent onEnter;
    [SerializeField] private UnityEvent onExit;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        onEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onExit?.Invoke();
    }
}
