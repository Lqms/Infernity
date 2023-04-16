using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePerkCard : MonoBehaviour
{
    [SerializeField] private MinigamePerksList _perkListLogic;

    [Header("UI")]
    [SerializeField] private Image _perkList;
    [SerializeField] private Image _activePerkInfo;

    [SerializeField] private Button _closePerksListButton;
    [SerializeField] private Button _openPerksListButton;
    [SerializeField] private Button _removeActivePerkButton;

    [SerializeField] private ContentSizeFitter _container;
    [SerializeField] private MinigamePerkDisplay _perkDisplayPrefab;

    private MinigamePerkData _activePerkData;

    private void OnEnable()
    {
        _openPerksListButton.onClick.AddListener(OnOpenPerksListButtonClicked);
        _closePerksListButton.onClick.AddListener(OnClosePerksListButtonClicked);
        _removeActivePerkButton.onClick.AddListener(OnRemoveActivePerkButtonClicked);
        MinigamePerkDisplay.ChoosePerkButtonClicked += OnChoosePerkButtonClicked;

        _perkListLogic.Changed += OnPerkListChanged;
    }

    private void OnDisable()
    {
        _openPerksListButton.onClick.RemoveListener(OnOpenPerksListButtonClicked);
        _closePerksListButton.onClick.RemoveListener(OnClosePerksListButtonClicked);
        _removeActivePerkButton.onClick.AddListener(OnRemoveActivePerkButtonClicked);
        MinigamePerkDisplay.ChoosePerkButtonClicked -= OnChoosePerkButtonClicked;

        _perkListLogic.Changed -= OnPerkListChanged;
    }

    private void Start()
    {
        InstantiatePerksList(); // потом будет вызываться по событию, когда у нас меняется список перков
    }

    private void OnPerkListChanged()
    {
        InstantiatePerksList();
    }

    private void InstantiatePerksList()
    {
        var perks = _container.GetComponentsInChildren<MinigamePerkDisplay>();

        foreach (var perk in perks)
        {
            Destroy(perk.gameObject);
        }

        foreach (var perk in _perkListLogic.Perks)
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

    private void OnChoosePerkButtonClicked(MinigamePerkData data, Transform perkParent)
    {
        if (perkParent != transform)
            return;

        _activePerkData = data;
        print(data.Logic + "эффект перка добавлен");
        _perkListLogic.ChangeList(_activePerkData, false);


        _activePerkInfo.gameObject.SetActive(true);
        _perkList.gameObject.SetActive(false);
    }

    private void OnRemoveActivePerkButtonClicked()
    {
        _activePerkInfo.gameObject.SetActive(false);
        _openPerksListButton.gameObject.SetActive(true);

        print("эффект перка убран");
        _perkListLogic.ChangeList(_activePerkData, true);
        _activePerkData = null;
    }
}
