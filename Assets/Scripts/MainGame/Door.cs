using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DoorSides
{
    Top,
    Right,
    Bottom,
    Left
}

[RequireComponent(typeof(Collider))]
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private DoorSides _side;
    [SerializeField] private Door _oppositeDoor;
    [SerializeField] private InteractableObjectOutline _model;
    [SerializeField] private ParticleSystem _burnVFX;
    [SerializeField] private Collider _collider;

    public Door OppositeDoor => _oppositeDoor;
    public ParticleSystem BurnVFX => _burnVFX;
    public DoorSides Side => _side;
    public bool Enabled { get; private set; }

    public static UnityAction<DoorSides> Entered;

    private void OnMouseOver()
    {
        _model.OutlineWidth = 10;
    }

    private void OnMouseExit()
    {
        _model.OutlineWidth = 0;
    }

    public void SwitchState(bool newState)
    {
        _model.gameObject.SetActive(newState);
        _collider.enabled = newState;
        Enabled = newState;
    }

    public void Use()
    {
        Entered?.Invoke(_oppositeDoor.Side);
    }
}
