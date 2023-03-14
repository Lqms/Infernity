using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_Portal : MonoBehaviour
{
    [SerializeField] private Reflecto_Projectile _prefab;
    [SerializeField] private Reflecto_PathCreator _pathCreator;

    private int _energy;

    public void Init(int energy)
    {
        _energy = energy;
    }

    public void Shoot(float speed)
    {
        _energy--;
        var projectile = Instantiate(_prefab, transform.position, Quaternion.identity);
        projectile.Init(_pathCreator.GetRandomPath(), _pathCreator.LastGeneratedPathColor, speed);

        if (_energy <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
