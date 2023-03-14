using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Minigame : MonoBehaviour
{
    public event UnityAction Victory;
    public event UnityAction Defeat;

    public virtual void StartGame()
    {

    }

    public virtual void EndGame(bool isPlayerWon)
    {
        if (isPlayerWon)
            Victory?.Invoke();
        else
            Defeat?.Invoke();
    }
}
