using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePerkCard : MonoBehaviour
{
    [SerializeField] private Image _perkList;
    [SerializeField] private Image _activePerkInfo;

    [SerializeField] private Button _closePerksListButton;
    [SerializeField] private Button _openPerksListButton;

    [SerializeField] private ContentSizeFitter _container;
    [SerializeField] private MinigamePerkDisplay _perkDisplayPrefab;

    private void OnEnable()
    {
        _openPerksListButton.onClick.AddListener(OnOpenPerksListButtonClicked);
        _closePerksListButton.onClick.AddListener(OnClosePerksListButtonClicked);
        MinigamePerkDisplay.ChoosePerkButtonClicked += OnChoosePerkButtonClicked;
    }

    private void OnDisable()
    {
        _openPerksListButton.onClick.RemoveListener(OnOpenPerksListButtonClicked);
        _closePerksListButton.onClick.RemoveListener(OnClosePerksListButtonClicked);
        MinigamePerkDisplay.ChoosePerkButtonClicked -= OnChoosePerkButtonClicked;

    }

    private void Start()
    {
        InstantiatePerksList(); // потом будет вызываться по событию, когда у нас меняется список перков
    }

    private void InstantiatePerksList()
    {
        List<string> opennedPerksList = new List<string>() { "Test", "Another test", "old test" }; // тут будет список с данными о перках, которые нашел игрок и они придут как параметр сюда

        foreach (var perk in opennedPerksList)
        {
            var perkObj = Instantiate(_perkDisplayPrefab, _container.transform);
            perkObj.Init(perk, transform);
        }
    }

    private void OnClosePerksListButtonClicked()
    {
        _perkList.gameObject.SetActive(false);
        _openPerksListButton.gameObject.SetActive(true);
    }

    private void OnOpenPerksListButtonClicked()
    {
        _perkList.gameObject.SetActive(true);
        _openPerksListButton.gameObject.SetActive(false);
    }

    private void OnChoosePerkButtonClicked(string info, Transform perkParent)
    {
        if (perkParent != transform)
            return;

        print(info);
        _activePerkInfo.gameObject.SetActive(true);
        _perkList.gameObject.SetActive(false);
    }
}
