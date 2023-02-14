using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MovementState : State
{
    public void MoveToPoint(Vector3 point)
    {
        if (ActiveCoroutine != null)
            StopCoroutine(ActiveCoroutine);

        Agent.speed = Constants.PlayerBaseMoveSpeed + PlayerStats.MovementSpeed * Constants.PlayerMovementSpeedCoeff;
        ActiveCoroutine = StartCoroutine(MovingToPoint(point));
    }

    private IEnumerator MovingToPoint(Vector3 point)
    {
        Agent.SetDestination(point);

        while (Vector3.Distance(transform.position, point) > Agent.radius * 2.5f)
            yield return null;

        Complete();
    }
}
