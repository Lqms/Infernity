using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Portal : MonoBehaviour, IInteractable
{
    public static event UnityAction Entered;

    public void Use()
    {
        print(gameObject.name);
        Entered?.Invoke();
    }
}
