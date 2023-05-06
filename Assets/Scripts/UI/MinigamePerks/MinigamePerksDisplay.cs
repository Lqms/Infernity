using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinigamePerksDisplay : MonoBehaviour
{
    [SerializeField] private Image _minigamePerkCards;

    private void OnEnable()
    {
        PlayerInput.OpenMinigamePerksKeyPressed += OnOpenMinigamePerksKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.OpenMinigamePerksKeyPressed -= OnOpenMinigamePerksKeyPressed;
    }

    private void OnOpenMinigamePerksKeyPressed()
    {
        _minigamePerkCards.gameObject.SetActive(!_minigamePerkCards.gameObject.activeSelf);
    }
}
