using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinigamePerkDisplay : MonoBehaviour
{
    [SerializeField] private Button _choosePerkButton;

    private Transform _parent;
    private string _perkName; // тут потом данные будут о перке передаваться

    public static event UnityAction<string, Transform> ChoosePerkButtonClicked;

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
        ChoosePerkButtonClicked?.Invoke(_perkName, _parent);
    }

    public void Init(string perkName, Transform cardParent)
    {
        _perkName = perkName;
        _parent = cardParent;
    }
}
