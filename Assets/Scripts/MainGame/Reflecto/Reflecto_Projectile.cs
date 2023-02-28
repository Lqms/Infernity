using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Reflecto_Projectile : MonoBehaviour
{
    private Tween _tween;

    public void Init(Vector3[] path)
    {
        _tween = transform.DOPath(path, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Reflecto_SwordCollider sword))
        {
            print("sword");
        }
        else
        {
            print("not sword");
        }

        _tween.Kill();
        Destroy(gameObject);
    }
}
