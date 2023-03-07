using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Reflecto_Projectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem _vfx;

    private Tween _tween;

    public void Init(Vector3[] path, Color color, float speed)
    {
        _vfx.startColor = color;

        float distance = 0;

        for (int i = 0; i < path.Length - 1; i++)
            distance += Vector3.Distance(path[i], path[i + 1]);

        _tween = transform.DOPath(path, distance / speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Reflecto_PlayerHealth player))
        {
            player.ApplyDamage(2);
            print("bam");
        }

        _tween.Kill();
        Destroy(gameObject);
    }
}
