using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombatState : State
{
    public void AttackToPoint(Vector3 point)
    {
        if (ActiveCoroutine != null)
            return;

        Animator.SetFloat(Constants.AnimationSpeedMultiplier, Constants.BaseAnimationSpeedMultiplier + PlayerStats.AttackSpeed * Constants.PlayerAttackSpeedCoeff);
        Agent.SetDestination(transform.position);
        transform.parent.DOLookAt(point, Constants.PlayerTurnRateCoeff / (Constants.PlayerBaseMoveSpeed + PlayerStats.MovementSpeed * Constants.PlayerMovementSpeedCoeff));
        ActiveCoroutine = StartCoroutine(Attacking()); 
    }

    private IEnumerator Attacking()
    {
        yield return new WaitForSeconds(BaseAnimationTime / (Constants.BaseAnimationSpeedMultiplier + PlayerStats.AttackSpeed * Constants.PlayerAttackSpeedCoeff));
        Complete();
    }
}
