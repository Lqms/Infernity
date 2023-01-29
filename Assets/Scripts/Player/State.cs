using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class State : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent Agent;
    [SerializeField] private bool _canBeInterrupted;

    protected Coroutine ActiveCoroutine;

    public bool CanBeInterrupted => _canBeInterrupted;

    public event UnityAction ActionCompleted;

    public virtual void OnEnable()
    {
        ActiveCoroutine = null;
        transform.rotation = transform.parent.rotation;
    }

    protected void Complete()
    {
        ActiveCoroutine = null;
        ActionCompleted?.Invoke();
    }
}
