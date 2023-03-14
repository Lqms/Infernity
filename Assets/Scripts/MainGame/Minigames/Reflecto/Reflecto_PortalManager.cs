using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Reflecto_PortalManager : MonoBehaviour
{
    [SerializeField] private Reflecto_Portal[] _portals;

    [Header("Settings")]
    [SerializeField] private float _speed = 5;
    [SerializeField] private int _energy = 5;
    [SerializeField] private float _minSpawnDelay;
    [SerializeField] private float _maxSpawnDelay;

    public event UnityAction AllPortalsDestroyed;

    private void Start()
    {
        foreach (var portal in _portals)
        {
            portal.Init(_energy);
        }

        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            var activePortals = _portals.Where(p => p.gameObject.activeSelf == true).ToArray();

            if (activePortals.Length == 0)
                break;

            activePortals[Random.Range(0, activePortals.Length)].Shoot(_speed);
        }

        print("all portals destroyed");
        AllPortalsDestroyed?.Invoke();
    }
}
