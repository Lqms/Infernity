using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private IdleState _idleState;
    [SerializeField] private MovementState _movementState;
    [SerializeField] private BlockState _blockState;
    [SerializeField] private CombatState[] _combatStates;

    private State _currentState;

    private void OnEnable()
    {
        PlayerInput.RightMouseButtonClicked += OnRightMouseButtonClicked;
        PlayerInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;
        PlayerInput.BlockKeyPressed += OnBlockKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.RightMouseButtonClicked -= OnRightMouseButtonClicked;
        PlayerInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;
        PlayerInput.BlockKeyPressed -= OnBlockKeyPressed;
    }

    private void Start()
    {
        _currentState = _idleState;
        _currentState.gameObject.SetActive(true);
    }

    private void OnActionCompleted()
    {
        ChangeState(_idleState);
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
        if (TryChangeState(_movementState))
            _movementState.MoveToPoint(HandleClick().point);
    }

    private void OnLeftMouseButtonClicked()
    {
        CombatState randomAttack = _combatStates[Random.Range(0, _combatStates.Length)];

        if (TryChangeState(randomAttack))
            randomAttack.AttackToPoint(HandleClick().point);
    }

    private void OnBlockKeyPressed(KeyCode key)
    {
        if (TryChangeState(_blockState))
            _blockState.Block(key);
    }

    private RaycastHit HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);

        return hitInfo;
    }
}
