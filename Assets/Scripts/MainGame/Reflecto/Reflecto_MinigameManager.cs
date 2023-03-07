using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_MinigameManager : MonoBehaviour
{
    [SerializeField] private PlayerStats _player;
    [SerializeField] private Reflecto_PortalManager _portalManager;
    [SerializeField] private Reflecto_PlayerRotator _reflectoPlayer;
    [SerializeField] private Room _room;

    private void OnEnable()
    {
        _player.gameObject.SetActive(false);

        _portalManager.AllPortalsDestroyed += OnAllPortalsDestroyed;
    }

    private void OnDisable()
    {
        _portalManager.AllPortalsDestroyed -= OnAllPortalsDestroyed;
    }

    private void OnAllPortalsDestroyed()
    {
        _reflectoPlayer.gameObject.SetActive(false);
        _player.gameObject.SetActive(true);
        _room.GeneratePortals();
    }
}
