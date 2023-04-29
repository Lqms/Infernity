using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PerksListDisplay : MonoBehaviour
{
    [SerializeField] private MinigamePerksList _perkListLogic;
    [SerializeField] private MinigamePerksListItemDisplay _minigamePerksListItemDisplayPrefab;

    [Header("UI")]
    [SerializeField] private ContentSizeFitter _container;
    [SerializeField] private Image _perkListWrapper;
    [SerializeField] private Button _closePerksListButton;

    [SerializeField]  private List<MinigamePerksListItemDisplay> _minigamePerksListItemsDisplay = new List<MinigamePerksListItemDisplay>();

    public event UnityAction<MinigamePerkData> PerkChosen;

    private void OnEnable()
    {
        _closePerksListButton.onClick.AddListener(OnClosePerksListButtonClicked);
        _perkListLogic.Changed += OnPerkListChanged;
    }

    private void OnDisable()
    {
        _closePerksListButton.onClick.RemoveListener(OnClosePerksListButtonClicked);
        _perkListLogic.Changed -= OnPerkListChanged;
        ClearPerksListItemsDisplay();
    }

    // переделать реакцией на событие PlayerInput
    private void Start()
    {
        InstantiatePerksList();
    }

    private void OnPerkListChanged()
    {
        InstantiatePerksList();
    }

    private void OnClosePerksListButtonClicked()
    {
        _perkListWrapper.gameObject.SetActive(false);
    }

    public void Open()
    {
        _perkListWrapper.gameObject.SetActive(true);
    }

    private void InstantiatePerksList()
    {
        ClearPerksListItemsDisplay();

        foreach (var perk in _perkListLogic.Perks)
        {
            var perkObj = Instantiate(_minigamePerksListItemDisplayPrefab, _container.transform);
            _minigamePerksListItemsDisplay.Add(perkObj);
            perkObj.Init(perk);
            perkObj.ChoosePerkButtonClicked += OnChoosePerkButtonClicked;
        }
    }

    private void ClearPerksListItemsDisplay()
    {
        while (_minigamePerksListItemsDisplay.Count > 0)
        {
            var perkToClear = _minigamePerksListItemsDisplay[0];
            perkToClear.ChoosePerkButtonClicked -= OnChoosePerkButtonClicked;
            _minigamePerksListItemsDisplay.Remove(perkToClear);
            Destroy(perkToClear.gameObject);
        }
    }

    private void OnChoosePerkButtonClicked(MinigamePerkData data)
    {
        print(data.Logic + "эффект перка добавлен");
        _perkListLogic.RemovePerk(data);
        PerkChosen?.Invoke(data);
        gameObject.SetActive(false);
    }
}
