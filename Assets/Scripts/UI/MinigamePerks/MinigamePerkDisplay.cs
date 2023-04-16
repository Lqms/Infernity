using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinigamePerkDisplay : MonoBehaviour
{
    [SerializeField] private Button _choosePerkButton;

    private Transform _parent;
    private MinigamePerkData _data; 

    public static event UnityAction<MinigamePerkData, Transform> ChoosePerkButtonClicked;

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
        ChoosePerkButtonClicked?.Invoke(_data, _parent);
    }

    public void Init(MinigamePerkData data, Transform cardParent)
    {
        _data = data;
        _parent = cardParent;
    }
}
