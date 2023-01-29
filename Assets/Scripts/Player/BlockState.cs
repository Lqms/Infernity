using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : State
{
    [SerializeField] private float _blockAnimationTime;

    public void Block(KeyCode key)
    {
        if (ActiveCoroutine != null)
            StopCoroutine(ActiveCoroutine);

        Agent.SetDestination(transform.position);
        ActiveCoroutine = StartCoroutine(Blocking(key));
    }

    private IEnumerator Blocking(KeyCode key)
    {
        while (Input.GetKeyUp(key) == false)
            yield return null;  

        Complete();
    }
}
