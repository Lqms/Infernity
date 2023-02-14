using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutState : State
{
    public void Shout()
    {
        if (ActiveCoroutine != null)
            return;

        Agent.SetDestination(transform.position);
        ActiveCoroutine = StartCoroutine(Shouting());
    }

    private IEnumerator Shouting()
    {
        yield return new WaitForSeconds(BaseAnimationTime);

        Complete();
    }
}
