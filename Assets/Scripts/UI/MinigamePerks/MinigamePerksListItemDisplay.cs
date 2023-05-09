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

        _choosePerkButton.GetComponent<Image>().color = RarityToColor(data.Rarity);
    }

    public Color RarityToColor(int rarity)
    {
        Color color;

        switch (rarity)
        {
            case 0:
                color = Color.grey;
                break;

            case 1:
                color = Color.green;
                break;

            case 2:
                color = Color.blue;
                break;

            case 3:
                color = Color.magenta;
                break;

            default:
                color = Color.cyan;
                break;
        }

        return color;
    }
}
