using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Perk Data", menuName = "Create New Perk Data", order = 54)]
public class MinigamePerkData : ScriptableObject
{
    [SerializeField] private string _header;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _rarity;

    [SerializeField] private string _logic;

    public string Header => _header;
    public string Description => _description;
    public Sprite Icon => _icon;
    public int Rarity => _rarity;
    public string Logic => _logic;
}
