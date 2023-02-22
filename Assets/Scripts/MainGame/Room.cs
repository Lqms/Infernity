using UnityEngine;
using UnityEngine.AI;

public class Room : MonoBehaviour
{
    [SerializeField] protected Transform Player;

    [Header("Room settings")]
    [SerializeField] private Portal[] _portals;
    [SerializeField] private Transform _enterPortal;

    protected virtual void OnEnable()
    {
        Player.GetComponent<NavMeshAgent>().enabled = false;
        Player.position = _enterPortal.position;
        Player.GetComponent<NavMeshAgent>().enabled = true;

        foreach (var portal in _portals)
            portal.gameObject.SetActive(false);
    }

    protected void GeneratePortals()
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
