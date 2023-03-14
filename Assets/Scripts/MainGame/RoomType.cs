using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    [SerializeField] private Room[] _rooms;

    public void ActivateRandomRoom()
    {
        var room = _rooms[Random.Range(0, _rooms.Length)];
        room.gameObject.SetActive(true);

        if (room.TryGetComponent(out Minigame minigame))
        {
            FindObjectOfType<MinigameManager>().MinigameEntered(minigame); // cheat-code
        }
    }
}
