using System.Collections;
using UnityEngine;

public class ImpSlice_EnemySpawner : MonoBehaviour
{
    [SerializeField] private ImpSlice_Enemy _enemy;
    [SerializeField] private float _timeBetweenSpawn = 3;

    private void Start()
    {
        SpawnPrefab();
    }

    private void OnEnable()
    {
        _enemy.Deactivated += OnEnemyDeactivated;
    }

    private void OnDisable()
    {
        _enemy.Deactivated -= OnEnemyDeactivated;
    }

    private void OnEnemyDeactivated()
    {
        StartCoroutine(Respawning());
    }

    private IEnumerator Respawning()
    {
        yield return new WaitForSeconds(2);
        SpawnPrefab();
    }

    private void SpawnPrefab()
    {
        float offsetX = 50;
        float offsetY = 50;
        float screenRandomX = Random.Range(offsetX, Screen.width - offsetX);
        float screenRandomY = Random.Range(Screen.height / 2, Screen.height - offsetY);
        Vector3 randomScreenPosition = new Vector3(screenRandomX, screenRandomY, 10);

        Vector3 randomWorldPosition = Camera.main.ScreenToWorldPoint(randomScreenPosition);
        _enemy.gameObject.SetActive(true);
        _enemy.Init(randomWorldPosition);
    }
}
