using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerClickHandler _clickHandler;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerInteractsHandler _interactsHandler;
    [SerializeField] private PlayerCombat _combat;

    public bool IsMoving => _movement.Velocity != Vector3.zero;
    public bool IsAttacking => _combat.AttackingCoroutine != null;
    public float AttackSpeed => _combat.AttackSpeed;

    private void OnEnable()
    {
        _input.RightMouseButtonClicked += OnRightMouseButtonClicked;
        _input.LeftMouseButtonClicked += OnLeftMouseButtonClicked;
    }

    private void OnDisable()
    {
        _input.RightMouseButtonClicked -= OnRightMouseButtonClicked;
        _input.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;
    }

    private void OnRightMouseButtonClicked()
    {
        if (IsAttacking)
            return;

        RaycastHit clickInfo = _clickHandler.HandleClick();

        if (clickInfo.collider != null && clickInfo.collider.TryGetComponent(out IInteractable interactableObject))
        {
            _interactsHandler.SetNewInteractableObject(interactableObject);
        }

        _movement.MoveToPoint(clickInfo.point);
    }

    private void OnLeftMouseButtonClicked()
    {
        RaycastHit clickInfo = _clickHandler.HandleClick();

        if (_combat.TryAttack())
        {
            _movement.RotateToPoint(clickInfo.point);
            _movement.StopMoving();
        }
    }
}
