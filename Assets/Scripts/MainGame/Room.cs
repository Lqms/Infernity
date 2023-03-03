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
        TeleportPlayer();

        foreach (var portal in _portals)
            portal.gameObject.SetActive(false);
    }

    private void TeleportPlayer()
    {
        Player.GetComponent<NavMeshAgent>().enabled = false;
        Player.position = _enterPortal.position;
        Player.GetComponent<NavMeshAgent>().enabled = true;
    }
}
