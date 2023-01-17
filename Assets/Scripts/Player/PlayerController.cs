using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerClickHandler _clickHandler;

    [Header("States")]
    [SerializeField] private MovementState _movement;
    [SerializeField] private CombatState _combat;
    [SerializeField] private IdleState _idle;

    private State _currentState;

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

    private void Start()
    {
        _currentState = _idle;
        _currentState.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_currentState.ActionIsOver == true && _currentState != _idle)
        {
            ChangeState(_idle);
        }
    }

    private void ChangeState(State newState)
    {
        _currentState.gameObject.SetActive(false);
        _currentState = newState;
        _currentState.gameObject.SetActive(true);
    }

    private void OnRightMouseButtonClicked()
    {
        RaycastHit clickInfo = _clickHandler.HandleClick();

        ChangeState(_movement);
        _movement.MoveToPoint(clickInfo.point);
    }

    private void OnLeftMouseButtonClicked()
    {
        RaycastHit clickInfo = _clickHandler.HandleClick();

        ChangeState(_combat);
        _combat.Attack(clickInfo.point);
    }
}
