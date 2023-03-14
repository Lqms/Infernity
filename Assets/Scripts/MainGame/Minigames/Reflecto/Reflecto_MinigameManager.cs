using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_MinigameManager : Minigame
{
    [SerializeField] private Reflecto_PortalManager _portalManager;
    [SerializeField] private Reflecto_Player _reflectoPlayer;

    public override void StartGame()
    {
        base.StartGame();

        _reflectoPlayer.gameObject.SetActive(true);

        _portalManager.AllPortalsDestroyed += OnAllPortalsDestroyed;
        _reflectoPlayer.HealthOver += OnPlayerHealthOver;
    }

    private void OnAllPortalsDestroyed()
    {
        EndGame(true);
    }

    private void OnPlayerHealthOver()
    {
        EndGame(false);
    }

    public override void EndGame(bool isPlayerWon)
    {
        _reflectoPlayer.gameObject.SetActive(false);

        _portalManager.AllPortalsDestroyed -= OnAllPortalsDestroyed;
        _reflectoPlayer.HealthOver -= OnPlayerHealthOver;

        base.EndGame(isPlayerWon);
    }
}
