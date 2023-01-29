using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombatState : State
{
    [SerializeField] private float _attackAnimationTime;

    public void AttackToPoint(Vector3 point)
    {
        if (ActiveCoroutine != null)
            return;

        Agent.SetDestination(transform.position);
        transform.parent.DOLookAt(point, 1 / 2); // 2 - скорость вращения
        ActiveCoroutine = StartCoroutine(Attacking()); 
    }

    private IEnumerator Attacking()
    {
        yield return new WaitForSeconds(_attackAnimationTime / 1); // 1 - скорость атаки, 2.33 - 1, 1.667 - 2 и 3 анимации атаки
        Complete();
    }
}
