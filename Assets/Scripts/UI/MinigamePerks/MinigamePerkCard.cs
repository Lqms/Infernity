using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePerkCard : MonoBehaviour
{
    [SerializeField] private PerksListDisplay _perksListDisplay;
    [SerializeField] ActivePerkInfoDisplay _activePerkInfoDisplay;
    [SerializeField] private Button _openPerksListButton;

    private void OnEnable()
    {
        _openPerksListButton.onClick.AddListener(OnOpenPerksListButtonClicked);
        _perksListDisplay.PerkChosen += OnPerkChosen;
    }

    private void OnDisable()
    {
        _openPerksListButton.onClick.RemoveListener(OnOpenPerksListButtonClicked);
        _perksListDisplay.PerkChosen -= OnPerkChosen;
    }

    private void OnOpenPerksListButtonClicked()
    {
        _perksListDisplay.Open();
    }

    private void OnPerkChosen(MinigamePerkData data)
    {
        _activePerkInfoDisplay.Init(data);
    }
}
