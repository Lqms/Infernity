using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    [SerializeField] private Room[] _rooms;

    public void ActivateRandomRoom()
    {
        _rooms[Random.Range(0, _rooms.Length)].gameObject.SetActive(true);
    }
}
