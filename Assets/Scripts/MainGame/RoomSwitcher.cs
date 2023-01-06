using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Room[] _rooms;

    private Room _current;

    private void Awake()
    {
        _current = _rooms[0];
        _current.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        Door.Entered += OnPlayerDoorEntered;
    }

    private void OnDisable()
    {
        Door.Entered -= OnPlayerDoorEntered;
    }

    private void OnPlayerDoorEntered(DoorSides side)
    {
        Switch();
        _current.Init(side);

        _playerMovement.Teleportate(_current.BurnedDoor.transform.position);
    }

    private void Switch()
    {
        _current.gameObject.SetActive(false);
        _current = _rooms[Random.Range(0, _rooms.Length)];
        _current.gameObject.SetActive(true);
    }
}
