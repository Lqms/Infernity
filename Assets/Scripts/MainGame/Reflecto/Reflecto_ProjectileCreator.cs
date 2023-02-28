using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_ProjectileCreator : MonoBehaviour
{
    [SerializeField] private Reflecto_Projectile _prefab;
    [SerializeField] private Reflecto_PathCreator _pathCreator;
    [SerializeField] private float _timeBetweenSpawn = 3;

    private WaitForSeconds _spawnDelay;

    private void Start()
    {
        _spawnDelay = new WaitForSeconds(_timeBetweenSpawn);
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return _spawnDelay;
            var projectile = Instantiate(_prefab, transform.position, Quaternion.identity);
            projectile.Init(_pathCreator.GetRandomPath());
        }
    }
}
