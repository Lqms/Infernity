using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_ProjectileCreator : MonoBehaviour
{
    [SerializeField] private Reflecto_Projectile _prefab;
    [SerializeField] private Reflecto_PathCreator _pathCreator;

    public void Shoot(float speed)
    {   
        var projectile = Instantiate(_prefab, transform.position, Quaternion.identity);
        projectile.Init(_pathCreator.GetRandomPath(), _pathCreator.LastGeneratedPathColor, speed);
    }
}
