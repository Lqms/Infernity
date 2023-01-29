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

        Agent.SetDestination(transform.position);
        transform.parent.DOLookAt(point, 1 / 2); // 2 - �������� ��������
        ActiveCoroutine = StartCoroutine(Attacking()); 
    }

    private IEnumerator Attacking()
    {
        yield return new WaitForSeconds(2.33f / 1); // 1 - �������� �����, 2.33 - 1, 1.667 - 2 � 3 �������� �����
        Complete();
    }
}
