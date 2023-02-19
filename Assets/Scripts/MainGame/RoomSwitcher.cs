using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    [SerializeField] private RoomType[] _roomTypes;

    private void OnEnable()
    {
        Portal.Entered += OnPortalEntered;
    }

    private void OnDisable()
    {
        Portal.Entered -= OnPortalEntered;
    }

    private void OnPortalEntered()
    {
        _roomTypes[Random.Range(0, _roomTypes.Length)].ActivateRandomRoom();
    }
}
