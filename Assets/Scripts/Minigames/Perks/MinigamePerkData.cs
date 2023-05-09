using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerkRarities
{
    Common,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "New Perk Data", menuName = "Create New Perk Data", order = 54)]
public class MinigamePerkData : ScriptableObject
{
    [SerializeField] private string _header;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private PerkRarities _rarity;

    [SerializeField] private string _logic;

    public string Header => _header;
    public string Description => _description;
    public Sprite Icon => _icon;
    public PerkRarities Rarity => _rarity;
    public Color Color => RarityToColor();

    public string Logic => _logic;


    private Color RarityToColor()
    {
        Color color = Color.gray;

        switch (_rarity)
        {
            case PerkRarities.Common:
                color = Color.grey;
                break;

            case PerkRarities.Rare:
                color = Color.green;
                break;

            case PerkRarities.Epic:
                color = Color.blue;
                break;

            case PerkRarities.Legendary:
                color = Color.magenta;
                break;
        }

        return color;
    }
}
