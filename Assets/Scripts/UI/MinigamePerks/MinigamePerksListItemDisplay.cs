using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinigamePerksListItemDisplay : MonoBehaviour
{
    [SerializeField] private Button _choosePerkButton;
    [SerializeField] private Text _header;
    [SerializeField] private Image _icon;

    private MinigamePerkData _data; 

    public event UnityAction<MinigamePerkData> ChoosePerkButtonClicked;

    private void OnEnable()
    {
        _choosePerkButton.onClick.AddListener(OnChoosePerkButtonClicked);
    }

    private void OnDisable()
    {
        _choosePerkButton.onClick.RemoveListener(OnChoosePerkButtonClicked);
    }

    private void OnChoosePerkButtonClicked()
    {
        ChoosePerkButtonClicked?.Invoke(_data);
    }

    public void Init(MinigamePerkData data)
    {
        _data = data;
        _icon.sprite = data.Icon;
        _header.text = data.Header;
        _choosePerkButton.GetComponent<Image>().color = data.Rarity;
    }
}
