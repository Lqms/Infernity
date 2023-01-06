using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _attackSpeed = 2;

    public Coroutine AttackingCoroutine { get; private set; }
    public float AttackSpeed => _attackSpeed;

    public bool TryAttack()
    {
        if (AttackingCoroutine != null)
            return false;

        AttackingCoroutine = StartCoroutine(Attacking(2.33f / _attackSpeed)); // 2.33 - время анимации атаки

        return true;
    }

    private IEnumerator Attacking(float animationTime)
    {
        yield return new WaitForSeconds(animationTime);
        AttackingCoroutine = null;
    }

}
