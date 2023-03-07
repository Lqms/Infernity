using UnityEngine;
using UnityEngine.AI;

public class Room : MonoBehaviour
{
    [SerializeField] private Portal[] _portals;
    [SerializeField] private Transform _enterPortal;
    [SerializeField] private Transform _player;

    private void OnEnable()
    {
        _player.GetComponent<NavMeshAgent>().enabled = false;
        _player.position = _enterPortal.position; 
        _player.GetComponent<NavMeshAgent>().enabled = true;
    }

    public void GeneratePortals()
    {
        int counter = 0;

        foreach (var portal in _portals)
        {
            int activePortal = Random.Range(0, 2);
            counter += activePortal;
            portal.gameObject.SetActive(System.Convert.ToBoolean(activePortal));
        }

        if (counter == 0)
            _portals[Random.Range(0, _portals.Length)].gameObject.SetActive(true);
    }
}
