using System.Collections;
using UnityEngine;

public class MovementState : State
{ 
    public void MoveToPoint(Vector3 point)
    {
        if (ActiveCoroutine != null)
            StopCoroutine(ActiveCoroutine);

        ActiveCoroutine = StartCoroutine(MovingToPoint(point));
    }

    private IEnumerator MovingToPoint(Vector3 point)
    {
        Agent.SetDestination(point);

        while (Vector3.Distance(transform.position, point) > Agent.radius + 0.1f)
            yield return null;

        Complete();
    }
}
