using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class State : MonoBehaviour
{

    [SerializeField] protected NavMeshAgent Agent;
    [SerializeField] protected Animator Animator;
    [SerializeField] private bool _canBeInterrupted;

    protected Coroutine ActiveCoroutine;
    protected float BaseAnimationTime;

    public bool CanBeInterrupted => _canBeInterrupted;

    public event UnityAction ActionCompleted;

    protected virtual void OnEnable()
    {
        ActiveCoroutine = null;
        transform.rotation = transform.parent.rotation;
        BaseAnimationTime = Animator.GetCurrentAnimatorStateInfo(0).length;
    }

    protected void Complete()
    {
        ActiveCoroutine = null;
        ActionCompleted?.Invoke();
    }
}
