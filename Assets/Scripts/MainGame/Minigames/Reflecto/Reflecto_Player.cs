using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reflecto_Player : MonoBehaviour
{
    [SerializeField] private Reflecto_PlayerInput _input;
    [SerializeField] private Reflecto_PlayerHealth _health;
    [SerializeField] private Reflecto_PlayerRotator _rotator;

    public event UnityAction HealthOver;

    private void OnEnable()
    {
        _health.Over += OnHealthOver;
        _input.RotateKeyPressed += OnRotateKeyPressed;
    }

    private void OnDisable()
    {
        _health.Over -= OnHealthOver;
        _input.RotateKeyPressed -= OnRotateKeyPressed;
    }

    private void OnHealthOver()
    {
        HealthOver?.Invoke();
    }

    private void OnRotateKeyPressed(Vector3 direction)
    {
        _rotator.Rotate(transform, direction, 0.3f); // 0.3f - от статов зависеть должно
    }
}
