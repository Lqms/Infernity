using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public bool ActionIsOver { get; protected set; }

    private void OnEnable()
    {
        transform.rotation = transform.parent.rotation;
        ActionIsOver = false;
    }
}
