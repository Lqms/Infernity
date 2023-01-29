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

    //
    private Coroutine _comboAttacksCoroutine;
    private int _currentAttackIndex = 0;
    private int _comboAttackTimer = 3;

    private IEnumerator ComboTimeCounting()
    {
        yield return new WaitForSeconds(_comboAttackTimer);

        _currentAttackIndex = 0;
        _comboAttacksCoroutine = null;
    }
    //

    private void OnEnable()
    {
        PlayerInput.RightMouseButtonClicking += OnRightMouseButtonClicking;
        PlayerInput.LeftMouseButtonClicking += OnLeftMouseButtonClicking;
        PlayerInput.BlockKeyPressed += OnBlockKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.RightMouseButtonClicking -= OnRightMouseButtonClicking;
        PlayerInput.LeftMouseButtonClicking -= OnLeftMouseButtonClicking;
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

    private void OnRightMouseButtonClicking()
    {
        if (TryChangeState(_movementState))
            _movementState.MoveToPoint(HandleClick().point);
    }

    private void OnLeftMouseButtonClicking()
    {
        CombatState attack = _combatStates[_currentAttackIndex];

        if (TryChangeState(attack))
        {
            MakeCombo();
            attack.AttackToPoint(HandleClick().point);
        }
    }

    private void MakeCombo()
    {
        if (_comboAttacksCoroutine == null)
        {
            _currentAttackIndex = 0;
        }
        else
        {
            _currentAttackIndex++;

            if (_currentAttackIndex >= _combatStates.Length)
                _currentAttackIndex = 0;

            StopCoroutine(_comboAttacksCoroutine);
        }

        _comboAttacksCoroutine = StartCoroutine(ComboTimeCounting());
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
