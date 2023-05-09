using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ActivePerkInfoDisplay : MonoBehaviour
{
    [SerializeField] private Text _header;
    [SerializeField] private Text _description;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;
    [SerializeField] private Button _removeActivePerkButton;
    [SerializeField] private MinigamePerksList _perkListLogic;

    [SerializeField] private Image _wrapper;

    private MinigamePerkData _activePerkData;

    public void Init(MinigamePerkData data)
    {
        _wrapper.gameObject.SetActive(true);

        _icon.sprite = data.Icon;
        _header.text = data.Header;
        _description.text = data.Description;
        // _background.color = MinigamePerksListItemDisplay. data.Rarity;

        _activePerkData = data;
    }

    private void OnEnable()
    {
        _removeActivePerkButton.onClick.AddListener(OnRemoveActivePerkButtonClicked);
    }

    private void OnDisable()
    {
        _removeActivePerkButton.onClick.AddListener(OnRemoveActivePerkButtonClicked);
    }

    private void OnRemoveActivePerkButtonClicked()
    {
        print("эффект перка убран");
        _perkListLogic.AddPerk(_activePerkData);
        _activePerkData = null;

        _wrapper.gameObject.SetActive(false);
    }
}
