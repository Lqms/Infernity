using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementState _movement;
    [SerializeField] private CombatState _combat;
    [SerializeField] private IdleState _idle;

    private State _currentState;

    private void OnEnable()
    {
        PlayerInput.RightMouseButtonClicked += OnRightMouseButtonClicked;
        PlayerInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;
    }

    private void OnDisable()
    {
        PlayerInput.RightMouseButtonClicked -= OnRightMouseButtonClicked;
        PlayerInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;
    }

    private void Start()
    {
        _currentState = _idle;
        _currentState.gameObject.SetActive(true);
    }

    private void OnActionCompleted()
    {
        ChangeState(_idle);
    }

    private bool TryChangeState(State newState)
    {
        if (_currentState.CanBeInterrupted == false)
            return false;

        ChangeState(newState);

        return true;
    }

    private void ChangeState(State newState)
    {
        if (newState == _currentState)
            return;

        _currentState.ActionCompleted -= OnActionCompleted;
        _currentState.gameObject.SetActive(false);

        _currentState = newState;

        _currentState.gameObject.SetActive(true);
        _currentState.ActionCompleted += OnActionCompleted;
    }

    private void OnRightMouseButtonClicked()
    {
        if (TryChangeState(_movement))
            _movement.MoveToPoint(HandleClick().point);
    }

    private void OnLeftMouseButtonClicked()
    {
        if (TryChangeState(_combat))
            _combat.AttackToPoint(HandleClick().point);
    }

    private RaycastHit HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);

        return hitInfo;
    }
}
