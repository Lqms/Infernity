using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombatState : State
{
    private Coroutine _attackingCoroutine;

    public bool CanAttack => _attackingCoroutine == null;

    public void Attack(Vector3 direction)
    {
        transform.parent.DOLookAt(direction, 1 / 2); // 2 - �������� ��������
        _attackingCoroutine = StartCoroutine(Attacking(2.33f / 1)); // 1 - �������� �����, 2.33 - 1, 1.667 - 2 � 3
    }

    private IEnumerator Attacking(float animationTime)
    {
        yield return new WaitForSeconds(animationTime);

        _attackingCoroutine = null;
        ActionIsOver = true;
    }
}
