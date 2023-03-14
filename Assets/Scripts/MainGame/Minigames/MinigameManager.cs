using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private Minigame _currentMinigame;

    public void MinigameEntered(Minigame minigame)
    {
        _currentMinigame = minigame;

        _currentMinigame.Victory += OnMinigameVictory;
        _currentMinigame.Defeat += OnMinigameDefeat;

        _currentMinigame.StartGame();
    }

    private void OnMinigameVictory()
    {
        _currentMinigame.Victory -= OnMinigameVictory;
        _currentMinigame.Defeat -= OnMinigameDefeat;

        print("victory");
    }

    private void OnMinigameDefeat()
    {
        _currentMinigame.Victory -= OnMinigameVictory;
        _currentMinigame.Defeat -= OnMinigameDefeat;

        print("defeat");
    }
}
