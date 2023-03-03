using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImpSlice_Enemy : MonoBehaviour
{
    private Coroutine _coroutine;

    public event UnityAction Deactivated;

    public void Init(Vector3 position)
    {
        transform.position = position;
        _coroutine = StartCoroutine(Despawning());
    }

    private IEnumerator Despawning()
    {
        yield return new WaitForSeconds(3);

        print("Not cutted");
        Deactivated?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ImpSlice_Pointer pointer))
        {
            print("Cutted!");

            StopCoroutine(_coroutine);
            Deactivated?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
