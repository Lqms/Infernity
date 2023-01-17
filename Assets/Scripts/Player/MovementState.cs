using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MovementState : State
{ 
    [SerializeField] private NavMeshAgent _agent;

    private Coroutine _movingCoroutine;

    public void MoveToPoint(Vector3 point)
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        _movingCoroutine = StartCoroutine(MovingToPoint(point));
    }

    private IEnumerator MovingToPoint(Vector3 point)
    {
        _agent.SetDestination(point);

        while (Vector3.Distance(transform.position, point) > _agent.radius)
            yield return null;

        _movingCoroutine = null;
        ActionIsOver = true;
    }
}
