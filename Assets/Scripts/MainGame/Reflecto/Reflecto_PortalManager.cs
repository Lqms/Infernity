using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_PortalManager : MonoBehaviour
{
    [SerializeField] private Reflecto_ProjectileCreator[] _portals;

    [Header("Settings")]
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _minSpawnDelay;
    [SerializeField] private float _maxSpawnDelay;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            _portals[Random.Range(0, _portals.Length)].Shoot(_speed);
        }
    }
}
